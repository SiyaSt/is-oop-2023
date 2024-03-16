using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain.CommandsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConsoleParser : IParser
{
    private readonly ICommandChain _commandChain;

    public ConsoleParser(ICommandChain commandChain)
    {
        _commandChain = commandChain;
    }

    public ParseResultTypes Parse(string commandText)
    {
        IList<string> list = commandText.Split().ToList();
        IEnumerator<string> enumerator = list.GetEnumerator();
        enumerator.MoveNext();
        ParseResultTypes result = _commandChain.Handle(new Request(enumerator));
        return result;
    }
}