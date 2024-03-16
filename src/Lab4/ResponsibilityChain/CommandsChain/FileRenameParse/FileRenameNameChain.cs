using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileRenameParse;

public class FileRenameNameChain : FileRenameArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileRenameModel.Builder builder)
    {
        builder.WithName(request.Command.Current);
        return new ArgumentsResultTypes.SuccessResult();
    }
}