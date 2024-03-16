namespace Lab5.Presentation.Console;

public interface IScenario
{
    public string ScenarioName { get; }

    public void Run();
}