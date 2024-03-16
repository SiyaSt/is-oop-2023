using Spectre.Console;

namespace Lab5.Presentation.Console;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selectionPrompt = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.ScenarioName);

        IScenario scenario = AnsiConsole.Prompt(selectionPrompt);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider scenarioProvider in _providers)
        {
            if (scenarioProvider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}