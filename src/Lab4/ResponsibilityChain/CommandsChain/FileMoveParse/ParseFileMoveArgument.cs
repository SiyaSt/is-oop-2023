using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain.FileMoveParse;

public class ParseFileMoveArgument : FileMoveArgumentChain
{
    private readonly IFileMoveArgumentChain? _fileMoveArgumentChain;

    public ParseFileMoveArgument(IFileMoveArgumentChain? fileMoveArgumentChain)
    {
        _fileMoveArgumentChain = fileMoveArgumentChain;
    }

    public override ArgumentsResultTypes Handle(Request request, FileMoveModel.Builder builder)
    {
        var result = new ArgumentsResultTypes();
        while (request.Command.MoveNext())
        {
            if (_fileMoveArgumentChain is null) return new ArgumentsResultTypes.ErrorResult("No chain");
            result = _fileMoveArgumentChain.Handle(request, builder);
            if (result is ArgumentsResultTypes.ErrorResult)
            {
                return result;
            }
        }

        return result;
    }
}