using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console;

public interface IScenarioProvider
{
   public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}