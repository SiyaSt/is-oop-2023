using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Composite;

public class Directory : IComponent
{
    public Directory(string name)
    {
        Components = new List<IComponent>();
        Name = name;
    }

    public string Name { get; }
    public IList<IComponent> Components { get; }

    public void Add(IComponent component)
    {
       Components.Add(component);
    }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitorT<Directory> newVisitor)
        {
            newVisitor.Visit(this);
        }
    }
}