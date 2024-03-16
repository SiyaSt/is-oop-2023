using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileDeleteParse;

public class FileDeletePathChain : FileDeleteArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileDeleteModel.Builder builder)
    {
        builder.WithPath(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}