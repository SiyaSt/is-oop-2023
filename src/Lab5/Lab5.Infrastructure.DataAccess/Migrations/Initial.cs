using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;
[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """

                create type command_name as enum
                (
                    'add',
                    'withdraw'
                );
                
                create table commands_history
                (
                    command_history_id bigint primary key generated always as identity,
                    account_id int not null,
                    command_name command_name not null,
                    command_value decimal not null
                );

                create table accounts
                (
                    account_id int bigint primary key generated always as identity,
                    account_number int not null
                    account_pin int not null,
                    account_balance decimal not null
                );
                """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
               drop table commands;
               drop table accounts;

               drop type command_name;

               """;
    }
}