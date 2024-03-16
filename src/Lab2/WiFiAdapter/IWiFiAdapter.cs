using Itmo.ObjectOrientedProgramming.Lab2.Component;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public interface IWiFiAdapter : IComponent, IWiFiDirect
{
    public int PowerConsumption { get; }
}