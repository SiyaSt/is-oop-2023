using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;

public interface ICoolerSystemBuilder
{
    ICoolerSystemBuilder WithDimension(Dimension dimensions);
    ICoolerSystemBuilder WithSocket(string socket);
    ICoolerSystemBuilder WithTdp(int tdp);
    ICoolerSystem Builder();
}