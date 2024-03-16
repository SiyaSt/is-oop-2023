using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Commands;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public UserAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider;
    }

    public Account? FindAccountById(long id)
    {
        const string sqlQuery = """
                               Select account_number, account_pin, account_balance
                               From accounts
                               Where account_number = @id;
                               """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();
        using var npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        npgsqlCommand.AddParameter("id", id);

        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            Id: reader.GetInt64(0),
            Pin: reader.GetInt32(1),
            Balance: reader.GetDecimal(2));
    }

    public decimal ShowBalance(long id)
    {
        const string sqlQuery = """
                                Select account_number, account_balance
                                From accounts
                                Where account_number = @id;
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();
        using var npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        npgsqlCommand.AddParameter("id", id);

        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
        reader.Read();

        return reader.GetDecimal(1);
    }

    public void OperationWithMoney(long id, decimal value)
    {
        const string sqlQuery = """
                                Update accounts
                                Set account_balance = @value
                                Where account_number = @id
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        npgsqlCommand.AddParameter("id", id);
        npgsqlCommand.AddParameter("value", value);

        npgsqlCommand.ExecuteNonQuery();
    }

    public IEnumerable<Command> ShowTransactionHistory(long id)
    {
        const string sqlQuery = """
                                Select account_id, command_name, command_value
                                From commands_history
                                Where account_id = @id
                                Order by command_history_id
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var npgsqlCommand = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        npgsqlCommand.AddParameter("id", id);

        using NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

        while (reader.Read())
        {
            yield return new Command(
                reader.GetInt64(0),
                reader.GetFieldValue<CommandName>(1),
                reader.GetDecimal(2));
        }
    }
}