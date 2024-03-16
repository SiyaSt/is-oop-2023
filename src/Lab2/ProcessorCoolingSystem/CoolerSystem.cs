using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public class CoolerSystem : ICoolerSystem
{
    public CoolerSystem(Dimension dimension, string socket, int tdp)
    {
        Dimension = dimension;
        Socket = socket;
        Tdp = tdp;
    }

    public Dimension Dimension { get; }
    public string Socket { get; }
    public int Tdp { get; }
    public ICoolerSystemBuilder Direct(ICoolerSystemBuilder coolerSystemBuilder)
    {
        coolerSystemBuilder.WithDimension(Dimension);
        coolerSystemBuilder.WithSocket(Socket);
        coolerSystemBuilder.WithTdp(Tdp);
        return coolerSystemBuilder;
    }
}