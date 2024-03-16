using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.TreeListParse;

public class DepthChain : TreeListArgumentChain
{
    public override ArgumentsResultTypes Handle(Request request, TreeListModel.Builder builder)
    {
        if (request.Command.Current != "-d")
        {
            return NextChain is not null ? NextChain.Handle(request, builder) :
                new ArgumentsResultTypes.ErrorResult("Error command flag");
        }

        request.Command.MoveNext();
        bool tryParse = int.TryParse((string?)request.Command.Current, out int depth);
        if (tryParse)
        {
            builder.WithDepth(depth);
        }

        return new ArgumentsResultTypes.SuccessResult();
    }
}
