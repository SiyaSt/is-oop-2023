using Itmo.ObjectOrientedProgramming.Lab4.Composite;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitorT<T> : IVisitor
    where T : IComponent
{
    void Visit(T components);
}