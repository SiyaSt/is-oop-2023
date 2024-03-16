using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileShowParse;

public class FileShowModeChain : FileShowArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, FileShowModel.Builder builder)
    {
        if (request.Command.Current != "-m")
        {
            return NextChain is not null ? NextChain.Handle(request, builder) :
                new ArgumentsResultTypes.ErrorResult("Error command flag");
        }

        request.Command.MoveNext();
        if (request.Command.Current != "console")
        {
            return new ArgumentsResultTypes.ErrorResult("Error command flag");
        }

        builder.WithMode(request.Command.Current);

        return new ArgumentsResultTypes.SuccessResult();
    }
}