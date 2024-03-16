namespace Lab5.Application.Models.Commands;

public record Command(long AccountId, CommandName CommandName, decimal Value);