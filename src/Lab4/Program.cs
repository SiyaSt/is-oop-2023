namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    private static void Main()
    {
        /*var chain = new Chain();
        var fileSystemContext = new FileSystemContext(
            null,
            null,
            ConfigurationManager.AppSettings.Get("sign1"),
            ConfigurationManager.AppSettings.Get("sign2"));
        var reader = new ConsoleReader();
        var parse = new ConsoleParser(chain.CommandChain);
        var writer = new ConsoleWriter();
        while (true)
        {
            string? commandText = reader.Read();
            if (commandText is null) continue;
            ParseResultTypes resultTypes = parse.Parse(commandText);
            if (resultTypes is ParseResultTypes.SuccessCommand command)
            {
                command.CommandResult.Execute(fileSystemContext);
            }
            else if (resultTypes is ParseResultTypes.ErrorCommand errorCommand)
            {
                writer.Write(errorCommand.Message);
            }
        }*/
    }
}