using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.ConnectParse;

public interface IConnectArgumentChain
{
    void AddNextChain(IConnectArgumentChain commandChain);
    ArgumentsResultTypes Handle(Request request, ConnectModel.Builder builder);
}