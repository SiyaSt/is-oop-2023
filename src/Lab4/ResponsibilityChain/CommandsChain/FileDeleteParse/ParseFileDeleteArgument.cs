using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileDeleteParse;

public class ParseFileDeleteArgument : FileDeleteArgumentChain
{
    private readonly IFileDeleteArgumentChain? _fileDeleteArgumentChain;

    public ParseFileDeleteArgument(IFileDeleteArgumentChain? fileDeleteArgumentChain)
    {
        _fileDeleteArgumentChain = fileDeleteArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, FileDeleteModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            if (_fileDeleteArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _fileDeleteArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}