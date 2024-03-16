using System;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public class CoolerSystemBuilder : ICoolerSystemBuilder
{
    private Dimension? _dimension;
    private string? _socket;
    private int _tdp;
    public ICoolerSystemBuilder WithDimension(Dimension dimensions)
    {
        _dimension = dimensions;
        return this;
    }

    public ICoolerSystemBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICoolerSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICoolerSystem Builder()
    {
        return new CoolerSystem(
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _tdp);
    }
}