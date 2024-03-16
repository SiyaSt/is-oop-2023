using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public class FileMoveSourcePathChain : FileMoveArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileMoveModel.Builder builder)
    {
        builder.WithSourcePath(request.Command.Current);
        request.Command.MoveNext();
        return NextChain is not null ? NextChain.Handle(request, builder) :
            new ArgumentsResultTypes.ErrorResult("Error command argument");
    }
}