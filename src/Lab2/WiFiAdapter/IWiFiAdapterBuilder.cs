namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithWiFiVersion(string version);
    IWiFiAdapterBuilder WithBluetooth(Bluetooth? bluetooth);
    IWiFiAdapterBuilder WithPciE(string pciE);
    IWiFiAdapterBuilder WithPowerConsumption(int power);
    IWiFiAdapter Builder();
}