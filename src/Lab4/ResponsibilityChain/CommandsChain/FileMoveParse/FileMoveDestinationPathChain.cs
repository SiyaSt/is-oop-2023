using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public class FileMoveDestinationPathChain : FileMoveArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileMoveModel.Builder builder)
    {
        builder.WithDestinationPath(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}