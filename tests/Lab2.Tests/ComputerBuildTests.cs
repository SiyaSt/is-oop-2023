using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerBuildResults;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Container;
using Itmo.ObjectOrientedProgramming.Lab2.DDR;
using Itmo.ObjectOrientedProgramming.Lab2.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Processor;
using Itmo.ObjectOrientedProgramming.Lab2.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Validation;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuildTests
{
    [Fact]
    public void SuccessfulComputerBuild()
    {
        // Arrange
        IList<IComputerValidation> computerValidations = new List<IComputerValidation>();
        computerValidations.Add(new MotherBoardValidation());
        computerValidations.Add(new ProcessorValidation());
        computerValidations.Add(new CaseValidation());
        computerValidations.Add(new PowerSupplyValidation());
        computerValidations.Add(new DdrValidation());
        var chipsetBuilder = new ChipsetBuilder();
        var processorBuilder = new ProcessorBuilder();
        var biosBuilder = new BiosBuilder();
        var ddrBuilder = new DdrBuilder();
        var motherBoardBuilder = new MotherboardBuilder();
        var coolerSystemBuilder = new CoolerSystemBuilder();
        var coolerSystemDimension = new Dimension(300, 300, 300);
        var ssdBuilder = new SsdBuilder();
        var computerCaseBuilder = new CaseBuilder();
        var computerCaseDimension = new Dimension(900, 400, 900);
        var videoCardBuilder = new VideoCardBuilder();
        var videoCardDimension = new Dimension(200, 400, 20);
        var powerSupplyBuilder = new PowerSupplyBuilder();
        var computerBuilder = new ComputerBuilder(computerValidations);
        var expectedResult = new ComputerBuildResultTypes.SuccessfulBuild(null);
        var container = new Container<IPowerSupply>(new List<IPowerSupply>());

        // Act
        chipsetBuilder.AddSupportingMemoryFrequency(1500);
        chipsetBuilder.WithXmp(null);
        IChipset chipset = chipsetBuilder.Build();
        processorBuilder.WithCoreFrequency(1000);
        processorBuilder.WithCoreAmount(4);
        processorBuilder.WithProcessorSocket("Socket H4");
        processorBuilder.AddMemoryFrequencies(16);
        processorBuilder.WithBuiltInVideoCore(null);
        processorBuilder.WithTdp(1000);
        processorBuilder.WithPowerConsumption(200);
        IProcessor processor = processorBuilder.Builder();
        biosBuilder.WithType("xxx");
        biosBuilder.WithVersion(4.0);
        biosBuilder.AddCpuCollection(processor);
        IBios bios = biosBuilder.Build();
        ddrBuilder.WithAvailableMemorySize(16);
        ddrBuilder.WithVoltage(10);
        ddrBuilder.WithFrequency(1000);
        ddrBuilder.AddXmp(null);
        ddrBuilder.AddDocp(null);
        ddrBuilder.WithVersion("ddr4");
        ddrBuilder.WithFormFactor("ddr4");
        ddrBuilder.WithPowerConsumption(50);
        IDdr ddr = ddrBuilder.Build();
        motherBoardBuilder.WithProcessorSocket("Socket H4");
        motherBoardBuilder.WithDdr(ddr);
        motherBoardBuilder.WithBios(bios);
        motherBoardBuilder.WithFormFactor(FormFactor.Atx);
        motherBoardBuilder.WithChipset(chipset);
        motherBoardBuilder.WithBuiltInWiFi(new BuiltInWiFi());
        motherBoardBuilder.WithOzuSlots(4);
        motherBoardBuilder.WithPciVersion(2);
        motherBoardBuilder.WithSataAmount(4);
        IMotherboard motherboard = motherBoardBuilder.Build();
        coolerSystemBuilder.WithTdp(1100);
        coolerSystemBuilder.WithSocket("Socket H4");
        coolerSystemBuilder.WithDimension(coolerSystemDimension);
        ICoolerSystem coolerSystem = coolerSystemBuilder.Builder();
        ssdBuilder.WithPciE("2");
        ssdBuilder.WithSata(null);
        ssdBuilder.WithMaxSpeed(100);
        ssdBuilder.WithMemoryCapacity(200);
        ssdBuilder.WithPowerConsumption(70);
        ISsd ssd = ssdBuilder.Builder();
        computerCaseBuilder.WithDimension(computerCaseDimension);
        computerCaseBuilder.WithHeightVideoCard(400);
        computerCaseBuilder.WithWidthVideoCard(200);
        computerCaseBuilder.WithMotherBoardFormFactor(FormFactor.Atx);
        ICase computerCase = computerCaseBuilder.Builder();
        videoCardBuilder.WithDimension(videoCardDimension);
        videoCardBuilder.WithPowerConsumption(60);
        videoCardBuilder.WithPciE(2);
        videoCardBuilder.WithChipFrequency(1000);
        videoCardBuilder.WithVideoStorageCapacity(300);
        IVideoCard videoCard = videoCardBuilder.Builder();
        powerSupplyBuilder.WithPeakLoad(600);
        IPowerSupply powerSupply = powerSupplyBuilder.Builder();
        container.AddComponent(powerSupply);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithDdr(ddr);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithSsd(ssd);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithCoolerSystem(coolerSystem);
        ComputerBuildResultTypes result = computerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Fact]
    public void SuccessfulBuildWithComment()
    {
       // Arrange
        IList<IComputerValidation> computerValidations = new List<IComputerValidation>();
        computerValidations.Add(new MotherBoardValidation());
        computerValidations.Add(new ProcessorValidation());
        computerValidations.Add(new CaseValidation());
        computerValidations.Add(new PowerSupplyValidation());
        computerValidations.Add(new DdrValidation());
        var chipsetBuilder = new ChipsetBuilder();
        var processorBuilder = new ProcessorBuilder();
        var biosBuilder = new BiosBuilder();
        var ddrBuilder = new DdrBuilder();
        var motherBoardBuilder = new MotherboardBuilder();
        var coolerSystemBuilder = new CoolerSystemBuilder();
        var coolerSystemDimension = new Dimension(300, 300, 300);
        var ssdBuilder = new SsdBuilder();
        var computerCaseBuilder = new CaseBuilder();
        var computerCaseDimension = new Dimension(900, 400, 900);
        var videoCardBuilder = new VideoCardBuilder();
        var videoCardDimension = new Dimension(200, 400, 20);
        var powerSupplyBuilder = new PowerSupplyBuilder();
        var computerBuilder = new ComputerBuilder(computerValidations);
        var expectedResult = new ComputerBuildResultTypes.SuccessfulBuildWithCommentary(null);
        var container = new Container<IPowerSupply>(new List<IPowerSupply>());

        // Act
        chipsetBuilder.AddSupportingMemoryFrequency(1500);
        chipsetBuilder.WithXmp(null);
        IChipset chipset = chipsetBuilder.Build();
        processorBuilder.WithCoreFrequency(1000);
        processorBuilder.WithCoreAmount(4);
        processorBuilder.WithProcessorSocket("Socket H4");
        processorBuilder.AddMemoryFrequencies(16);
        processorBuilder.WithBuiltInVideoCore(null);
        processorBuilder.WithTdp(1000);
        processorBuilder.WithPowerConsumption(200);
        IProcessor processor = processorBuilder.Builder();
        biosBuilder.WithType("xxx");
        biosBuilder.WithVersion(4.0);
        biosBuilder.AddCpuCollection(processor);
        IBios bios = biosBuilder.Build();
        ddrBuilder.WithAvailableMemorySize(16);
        ddrBuilder.WithVoltage(10);
        ddrBuilder.WithFrequency(1000);
        ddrBuilder.AddXmp(null);
        ddrBuilder.AddDocp(null);
        ddrBuilder.WithVersion("ddr4");
        ddrBuilder.WithFormFactor("ddr4");
        ddrBuilder.WithPowerConsumption(50);
        IDdr ddr = ddrBuilder.Build();
        motherBoardBuilder.WithProcessorSocket("Socket H4");
        motherBoardBuilder.WithDdr(ddr);
        motherBoardBuilder.WithBios(bios);
        motherBoardBuilder.WithFormFactor(FormFactor.Atx);
        motherBoardBuilder.WithChipset(chipset);
        motherBoardBuilder.WithBuiltInWiFi(new BuiltInWiFi());
        motherBoardBuilder.WithOzuSlots(4);
        motherBoardBuilder.WithPciVersion(2);
        motherBoardBuilder.WithSataAmount(4);
        IMotherboard motherboard = motherBoardBuilder.Build();
        coolerSystemBuilder.WithTdp(1100);
        coolerSystemBuilder.WithSocket("Socket H4");
        coolerSystemBuilder.WithDimension(coolerSystemDimension);
        ICoolerSystem coolerSystem = coolerSystemBuilder.Builder();
        ssdBuilder.WithPciE("2");
        ssdBuilder.WithSata(null);
        ssdBuilder.WithMaxSpeed(100);
        ssdBuilder.WithMemoryCapacity(200);
        ssdBuilder.WithPowerConsumption(70);
        ISsd ssd = ssdBuilder.Builder();
        computerCaseBuilder.WithDimension(computerCaseDimension);
        computerCaseBuilder.WithHeightVideoCard(400);
        computerCaseBuilder.WithWidthVideoCard(200);
        computerCaseBuilder.WithMotherBoardFormFactor(FormFactor.Atx);
        ICase computerCase = computerCaseBuilder.Builder();
        videoCardBuilder.WithDimension(videoCardDimension);
        videoCardBuilder.WithPowerConsumption(60);
        videoCardBuilder.WithPciE(2);
        videoCardBuilder.WithChipFrequency(1000);
        videoCardBuilder.WithVideoStorageCapacity(300);
        IVideoCard videoCard = videoCardBuilder.Builder();
        powerSupplyBuilder.WithPeakLoad(360);
        IPowerSupply powerSupply = powerSupplyBuilder.Builder();
        container.AddComponent(powerSupply);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithDdr(ddr);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithSsd(ssd);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithCoolerSystem(coolerSystem);
        ComputerBuildResultTypes result = computerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Fact]
    public void BuildWithDisclaimer()
    {
        // Arrange
        IList<IComputerValidation> computerValidations = new List<IComputerValidation>();
        computerValidations.Add(new MotherBoardValidation());
        computerValidations.Add(new ProcessorValidation());
        computerValidations.Add(new CaseValidation());
        computerValidations.Add(new PowerSupplyValidation());
        computerValidations.Add(new DdrValidation());
        var chipsetBuilder = new ChipsetBuilder();
        var processorBuilder = new ProcessorBuilder();
        var biosBuilder = new BiosBuilder();
        var ddrBuilder = new DdrBuilder();
        var motherBoardBuilder = new MotherboardBuilder();
        var coolerSystemBuilder = new CoolerSystemBuilder();
        var coolerSystemDimension = new Dimension(300, 300, 300);
        var ssdBuilder = new SsdBuilder();
        var computerCaseBuilder = new CaseBuilder();
        var computerCaseDimension = new Dimension(900, 400, 900);
        var videoCardBuilder = new VideoCardBuilder();
        var videoCardDimension = new Dimension(200, 400, 20);
        var powerSupplyBuilder = new PowerSupplyBuilder();
        var computerBuilder = new ComputerBuilder(computerValidations);
        var expectedResult = new ComputerBuildResultTypes.BuildWithDisclaimer(null);
        var container = new Container<IPowerSupply>(new List<IPowerSupply>());

        // Act
        chipsetBuilder.AddSupportingMemoryFrequency(1500);
        chipsetBuilder.WithXmp(null);
        IChipset chipset = chipsetBuilder.Build();
        processorBuilder.WithCoreFrequency(1000);
        processorBuilder.WithCoreAmount(4);
        processorBuilder.WithProcessorSocket("Socket H4");
        processorBuilder.AddMemoryFrequencies(16);
        processorBuilder.WithBuiltInVideoCore(null);
        processorBuilder.WithTdp(1000);
        processorBuilder.WithPowerConsumption(200);
        IProcessor processor = processorBuilder.Builder();
        biosBuilder.WithType("xxx");
        biosBuilder.WithVersion(4.0);
        biosBuilder.AddCpuCollection(processor);
        IBios bios = biosBuilder.Build();
        ddrBuilder.WithAvailableMemorySize(16);
        ddrBuilder.WithVoltage(10);
        ddrBuilder.WithFrequency(1000);
        ddrBuilder.AddXmp(null);
        ddrBuilder.AddDocp(null);
        ddrBuilder.WithVersion("ddr4");
        ddrBuilder.WithFormFactor("ddr4");
        ddrBuilder.WithPowerConsumption(50);
        IDdr ddr = ddrBuilder.Build();
        motherBoardBuilder.WithProcessorSocket("Socket H4");
        motherBoardBuilder.WithDdr(ddr);
        motherBoardBuilder.WithBios(bios);
        motherBoardBuilder.WithFormFactor(FormFactor.Atx);
        motherBoardBuilder.WithChipset(chipset);
        motherBoardBuilder.WithBuiltInWiFi(new BuiltInWiFi());
        motherBoardBuilder.WithOzuSlots(4);
        motherBoardBuilder.WithPciVersion(2);
        motherBoardBuilder.WithSataAmount(4);
        IMotherboard motherboard = motherBoardBuilder.Build();
        coolerSystemBuilder.WithTdp(900);
        coolerSystemBuilder.WithSocket("Socket H4");
        coolerSystemBuilder.WithDimension(coolerSystemDimension);
        ICoolerSystem coolerSystem = coolerSystemBuilder.Builder();
        ssdBuilder.WithPciE("2");
        ssdBuilder.WithSata(null);
        ssdBuilder.WithMaxSpeed(100);
        ssdBuilder.WithMemoryCapacity(200);
        ssdBuilder.WithPowerConsumption(70);
        ISsd ssd = ssdBuilder.Builder();
        computerCaseBuilder.WithDimension(computerCaseDimension);
        computerCaseBuilder.WithHeightVideoCard(400);
        computerCaseBuilder.WithWidthVideoCard(200);
        computerCaseBuilder.WithMotherBoardFormFactor(FormFactor.Atx);
        ICase computerCase = computerCaseBuilder.Builder();
        videoCardBuilder.WithDimension(videoCardDimension);
        videoCardBuilder.WithPowerConsumption(60);
        videoCardBuilder.WithPciE(2);
        videoCardBuilder.WithChipFrequency(1000);
        videoCardBuilder.WithVideoStorageCapacity(300);
        IVideoCard videoCard = videoCardBuilder.Builder();
        powerSupplyBuilder.WithPeakLoad(600);
        IPowerSupply powerSupply = powerSupplyBuilder.Builder();
        container.AddComponent(powerSupply);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithDdr(ddr);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithSsd(ssd);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithCoolerSystem(coolerSystem);
        ComputerBuildResultTypes result = computerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult.GetType(), result.GetType());
    }

    [Fact]
    public void NotSuccessfulBuild()
    {
        // Arrange
        IList<IComputerValidation> computerValidations = new List<IComputerValidation>();
        computerValidations.Add(new MotherBoardValidation());
        computerValidations.Add(new ProcessorValidation());
        computerValidations.Add(new CaseValidation());
        computerValidations.Add(new PowerSupplyValidation());
        computerValidations.Add(new DdrValidation());
        var chipsetBuilder = new ChipsetBuilder();
        var processorBuilder = new ProcessorBuilder();
        var biosBuilder = new BiosBuilder();
        var ddrBuilder = new DdrBuilder();
        var motherBoardBuilder = new MotherboardBuilder();
        var coolerSystemBuilder = new CoolerSystemBuilder();
        var coolerSystemDimension = new Dimension(300, 300, 300);
        var ssdBuilder = new SsdBuilder();
        var computerCaseBuilder = new CaseBuilder();
        var computerCaseDimension = new Dimension(900, 400, 900);
        var videoCardBuilder = new VideoCardBuilder();
        var videoCardDimension = new Dimension(200, 400, 20);
        var powerSupplyBuilder = new PowerSupplyBuilder();
        var computerBuilder = new ComputerBuilder(computerValidations);
        var expectedResult = new ComputerBuildResultTypes.FailedBuild(null, null);
        var container = new Container<IPowerSupply>(new List<IPowerSupply>());

        // Act
        chipsetBuilder.AddSupportingMemoryFrequency(1500);
        chipsetBuilder.WithXmp(null);
        IChipset chipset = chipsetBuilder.Build();
        processorBuilder.WithCoreFrequency(1000);
        processorBuilder.WithCoreAmount(4);
        processorBuilder.WithProcessorSocket("Socket H3");
        processorBuilder.AddMemoryFrequencies(16);
        processorBuilder.WithBuiltInVideoCore(null);
        processorBuilder.WithTdp(1000);
        processorBuilder.WithPowerConsumption(200);
        IProcessor processor = processorBuilder.Builder();
        biosBuilder.WithType("xxx");
        biosBuilder.WithVersion(4.0);
        biosBuilder.AddCpuCollection(processor);
        IBios bios = biosBuilder.Build();
        ddrBuilder.WithAvailableMemorySize(16);
        ddrBuilder.WithVoltage(10);
        ddrBuilder.WithFrequency(1000);
        ddrBuilder.AddXmp(null);
        ddrBuilder.AddDocp(null);
        ddrBuilder.WithVersion("ddr4");
        ddrBuilder.WithFormFactor("ddr4");
        ddrBuilder.WithPowerConsumption(50);
        IDdr ddr = ddrBuilder.Build();
        motherBoardBuilder.WithProcessorSocket("Socket H4");
        motherBoardBuilder.WithDdr(ddr);
        motherBoardBuilder.WithBios(bios);
        motherBoardBuilder.WithFormFactor(FormFactor.Atx);
        motherBoardBuilder.WithChipset(chipset);
        motherBoardBuilder.WithBuiltInWiFi(new BuiltInWiFi());
        motherBoardBuilder.WithOzuSlots(4);
        motherBoardBuilder.WithPciVersion(2);
        motherBoardBuilder.WithSataAmount(4);
        IMotherboard motherboard = motherBoardBuilder.Build();
        coolerSystemBuilder.WithTdp(1100);
        coolerSystemBuilder.WithSocket("Socket H4");
        coolerSystemBuilder.WithDimension(coolerSystemDimension);
        ICoolerSystem coolerSystem = coolerSystemBuilder.Builder();
        ssdBuilder.WithPciE("2");
        ssdBuilder.WithSata(null);
        ssdBuilder.WithMaxSpeed(100);
        ssdBuilder.WithMemoryCapacity(200);
        ssdBuilder.WithPowerConsumption(70);
        ISsd ssd = ssdBuilder.Builder();
        computerCaseBuilder.WithDimension(computerCaseDimension);
        computerCaseBuilder.WithHeightVideoCard(400);
        computerCaseBuilder.WithWidthVideoCard(200);
        computerCaseBuilder.WithMotherBoardFormFactor(FormFactor.Atx);
        ICase computerCase = computerCaseBuilder.Builder();
        videoCardBuilder.WithDimension(videoCardDimension);
        videoCardBuilder.WithPowerConsumption(60);
        videoCardBuilder.WithPciE(2);
        videoCardBuilder.WithChipFrequency(1000);
        videoCardBuilder.WithVideoStorageCapacity(300);
        IVideoCard videoCard = videoCardBuilder.Builder();
        powerSupplyBuilder.WithPeakLoad(600);
        IPowerSupply powerSupply = powerSupplyBuilder.Builder();
        container.AddComponent(powerSupply);
        computerBuilder.WithComputerCase(computerCase);
        computerBuilder.WithDdr(ddr);
        computerBuilder.WithMotherBoard(motherboard);
        computerBuilder.WithProcessor(processor);
        computerBuilder.WithPowerSupply(powerSupply);
        computerBuilder.WithSsd(ssd);
        computerBuilder.WithVideoCard(videoCard);
        computerBuilder.WithCoolerSystem(coolerSystem);
        ComputerBuildResultTypes result = computerBuilder.Build();

        // Assert
        Assert.Equal(expectedResult.GetType(), result.GetType());
    }
}