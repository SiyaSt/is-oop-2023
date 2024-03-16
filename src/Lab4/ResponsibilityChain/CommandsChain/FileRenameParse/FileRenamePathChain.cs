using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public class FileRenamePathChain : FileRenameArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileRenameModel.Builder builder)
    {
        builder.WithPath(request.Command.Current);
        request.Command.MoveNext();
        return NextChain is not null ? NextChain.Handle(request, builder) :
            new ArgumentsResultTypes.ErrorResult("Error command argument");
    }
}