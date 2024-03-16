using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstraction.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminAccountRepository : IAdminAccountRepository
{
    private readonly IPostgresConnectionProvider _postgresConnectionProvider;

    public AdminAccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _postgresConnectionProvider = connectionProvider;
    }

    public void CreateAccount(long id, int pin, decimal value)
    {
        const string sqlQuery = """
                                Insert into accounts(account_number, account_pin, account_balance)
                                Values (@id, @pin, @value)
                                """;
        NpgsqlConnection npgsqlConnection = Task
            .Run(async () => await _postgresConnectionProvider.GetConnectionAsync(default).ConfigureAwait(false))
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sqlQuery, npgsqlConnection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("pin", pin);
        command.Parameters.AddWithValue("value", value);

        command.ExecuteNonQuery();
    }
}