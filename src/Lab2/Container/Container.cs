using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Container;

public class Container<T>
{
    private readonly IList<T> _container;
    public Container(IList<T> container)
    {
        _container = container;
    }

    public void AddComponent(T component)
    {
        _container.Add(component);
    }

    public T GetComponent(int firstKey)
    {
        return _container[firstKey];
    }
}