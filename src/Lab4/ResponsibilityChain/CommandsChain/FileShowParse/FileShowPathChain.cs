using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public class FileShowPathChain : FileShowArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileShowModel.Builder builder)
    {
        builder.WithPath(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}