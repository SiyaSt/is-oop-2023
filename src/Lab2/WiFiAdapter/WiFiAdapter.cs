namespace Itmo.ObjectOrientedProgramming.Lab2.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    internal WiFiAdapter(string wiFiVersion, Bluetooth? bluetooth, string pciE, int powerConsumption)
    {
        WiFiVersion = wiFiVersion;
        Bluetooth = bluetooth;
        PciE = pciE;
        PowerConsumption = powerConsumption;
    }

    public string WiFiVersion { get; }
    public Bluetooth? Bluetooth { get; }
    public string PciE { get; }
    public int PowerConsumption { get; }
    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder wiFiAdapterBuilder)
    {
        wiFiAdapterBuilder.WithWiFiVersion(WiFiVersion);
        wiFiAdapterBuilder.WithBluetooth(Bluetooth);
        wiFiAdapterBuilder.WithPciE(PciE);
        wiFiAdapterBuilder.WithPowerConsumption(PowerConsumption);
        return wiFiAdapterBuilder;
    }
}