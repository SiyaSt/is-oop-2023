using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileCopyParse;

public class ParseFileCopyArgument : FileCopyArgumentChain
{
    private readonly IFileCopyArgumentChain? _fileCopyArgumentChain;

    public ParseFileCopyArgument(IFileCopyArgumentChain? fileCopyArgumentChain)
    {
        _fileCopyArgumentChain = fileCopyArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, FileCopyModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            if (_fileCopyArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _fileCopyArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}