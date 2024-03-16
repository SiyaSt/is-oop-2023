using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResponsibilityChain;

public record Request(IEnumerator<string> Command);