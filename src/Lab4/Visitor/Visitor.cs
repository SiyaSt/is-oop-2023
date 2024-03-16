using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class Visitor : IVisitorT<Directory>
{
    private readonly IWriter _writer = new ConsoleWriter();
    private int _signNumber = 3;
    private string? _sign1;
    private string? _sign2;
    public Visitor(string? sign1, string? sing2)
    {
        _sign1 = sign1;
        _sign2 = sing2;
    }

    public void Visit(Directory components)
    {
        _writer.Write(_sign1 + string.Join(string.Empty, Enumerable.Repeat(_sign2, _signNumber)) + components.Name);
        _signNumber += 2;
        foreach (IComponent component in components.Components)
        {
            component.Accept(this);
        }

        _signNumber -= 2;
    }
}