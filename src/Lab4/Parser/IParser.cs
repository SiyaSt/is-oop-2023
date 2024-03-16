using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public interface IParser
{
     ParseResultTypes Parse(string commandText);
}