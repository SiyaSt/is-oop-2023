using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain;

public interface ICommandChain
{
    void AddNextChain(ICommandChain commandChain);
    ParseResultTypes Handle(Request request);
}