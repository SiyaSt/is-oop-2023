using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _version;
    private Bluetooth? _bluetooth;
    private string? _pciE;
    private int _powerConsumption;

    public IWiFiAdapterBuilder WithWiFiVersion(string version)
    {
        _version = version;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetooth(Bluetooth? bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiAdapterBuilder WithPciE(string pciE)
    {
        _pciE = pciE;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(int power)
    {
        _powerConsumption = power;
        return this;
    }

    public IWiFiAdapter Builder()
    {
        return new WiFiAdapter(
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _bluetooth,
            _pciE ?? throw new ArgumentNullException(nameof(_pciE)),
            _powerConsumption);
    }
}