using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstraction.Repositories;
using Lab5.Application.Models.Commands;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class CommandRepository : ICommandRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public CommandRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider;
    }

    public void AddWithdrawOperationToHistory(long id, decimal value)
    {
        const string sqlQuery = """
                                Insert into commands_history(account_id, command_name, command_value)
                                Values (@id, @commandType, @value)
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("commandType", CommandName.Withdraw);
        command.Parameters.AddWithValue("value", value);

        command.ExecuteNonQuery();
    }

    public void AddAddOperationToHistory(long id, decimal value)
    {
        const string sqlQuery = """
                                Insert into commands_history(account_id, command_name, command_value)
                                Values (@id, @name, @value)
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("name", CommandName.Add);
        command.Parameters.AddWithValue("value", value);

        command.ExecuteNonQuery();
    }
}