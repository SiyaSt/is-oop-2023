using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.DisconnectParse;

public interface IDisconnectArgumentChain
{
    void AddNextChain(IDisconnectArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, DisconnectModel.Builder builder);
}