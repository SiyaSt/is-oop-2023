using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public class FileCopyDestinationPath : FileCopyArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileCopyModel.Builder builder)
    {
        builder.WithDestinationPath(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}