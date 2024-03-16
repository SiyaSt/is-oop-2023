using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public interface IComponent
{
    void Add(IComponent component);
    void Accept(IVisitor visitor);
}