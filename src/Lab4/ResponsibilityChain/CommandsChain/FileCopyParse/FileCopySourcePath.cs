using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public class FileCopySourcePath : FileCopyArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileCopyModel.Builder builder)
    {
        builder.WithSourcePath(request.Command.Current);
        request.Command.MoveNext();
        return NextChain is not null ? NextChain.Handle(request, builder) :
            new ArgumentsResultTypes.ErrorResult("Error command argument");
    }
}