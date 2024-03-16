using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceEnvironment;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.SpacePetrolStation;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRouteResults;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShipRoutes;
using Itmo.ObjectOrientedProgramming.Lab1.Time;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SpaceShipTests
{
    public static IEnumerable<object[]> SpaceShipData1 =>
        new List<object[]>
        {
            new object[] { new PleasureShuttle(), new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult() },
            new object[] { new Augur(false), new Results.SpaceShipRouteResult.ShipLossSpaceShipRouteResult() },
        };

    public static IEnumerable<object[]> SpaceShipData2 =>
        new List<object[]>
        {
            new object[] { new Vaclas(false), new Results.ObstaclesResults.CrewLossSpaceShipRouteResult() },
            new object[]
            {
                new Vaclas(true),
                new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(
                    new IFuel[] { new GravitationalMatter(0) },
                    new ITime[] { new Time.Time(0) }),
            },
        };

    public static IEnumerable<object[]> SpaceShipData3 =>
        new List<object[]>
        {
            new object[] { new Vaclas(false), new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult() },
            new object[]
            {
                new Meredian(false),
                new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(
                    new IFuel[] { new ActivePlasma(0) },
                    new ITime[] { new Time.Time(0) }),
            },
            new object[]
            {
                new Augur(false),
                new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(
                    new IFuel[] { new ActivePlasma(0) },
                    new ITime[] { new Time.Time(0) }),
            },
        };

    public static IEnumerable<object[]> SpaceShipData4 =>
        new List<object[]>
        {
            new object[] { new PleasureShuttle(), new Results.ObstaclesResults.ShipDestructionSpaceShipRouteResult() },
            new object[]
            {
                new Stella(false),
                new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(
                    new IFuel[] { new ActivePlasma(0), new ActivePlasma(0) },
                    new ITime[] { new Time.Time(0) }),
            },
            new object[]
            {
                new Augur(false),
                new Results.SpaceShipRouteResult.SuccessSpaceShipRouteResult(
                    new IFuel[] { new ActivePlasma(0), new ActivePlasma(0) },
                    new ITime[] { new Time.Time(0) }),
            },
        };

    [Theory]
    [MemberData(nameof(SpaceShipData1))]
    public void ShipsShouldNotFlyDueToLackOfResources(
        ISpaceShip spaceShip,
        Results.SpaceShipRouteResult expectedSpaceShipRouteResult)
    {
        // Arrange
        const int distance = 3000;
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        var obstacle = new AntimatterFlare();
        var nebulaSpace = new NebulaSpace(obstacle, 0, distance);
        spaceEnvironments.Add(nebulaSpace);
        var route = new Route(spaceEnvironments);
        Results result;

        // Act
        result = route.ShipJourney(spaceShip);

        // Assert
        Assert.Equal(expectedSpaceShipRouteResult.GetType(), result.GetType());
    }

    [Theory]
    [MemberData(nameof(SpaceShipData2))]
    public void FirstShipMustNotPassRouteBecauseOfLossOfCrewSecondShipMustCompleteItSuccessfully(
        ISpaceShip spaceShip,
        Results expectedSpaceShipRouteResult)
    {
        // Arrange
        const int amountOfObstacles = 1;
        var antimatterFlare = new AntimatterFlare();
        var nebulaSpace = new NebulaSpace(antimatterFlare, amountOfObstacles, 0);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(nebulaSpace);
        var route = new Route(spaceEnvironments);

        // Act
        Results spaceShipRouteResult = route.ShipJourney(spaceShip);

        // Assert
        Assert.Equal(expectedSpaceShipRouteResult.GetType(), spaceShipRouteResult.GetType());
    }

    [Theory]
    [MemberData(nameof(SpaceShipData3))]
    public void FirstShipMustBeDestroyedOtherTwoMustPassSuccessfully(
        ISpaceShip spaceShip,
        Results expectedSpaceShipRouteResult)
    {
        // Arrange
        const int amountOfObstacles = 1;
        var spaceWhale = new SpaceWhale();
        var nitriteNebulaSpace = new NitriteNebulaSpace(spaceWhale, amountOfObstacles, 0);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(nitriteNebulaSpace);
        var route = new Route(spaceEnvironments);

        // Act
        Results spaceShipRouteResult = route.ShipJourney(spaceShip);

        // Assert
        Assert.Equal(expectedSpaceShipRouteResult.GetType(), spaceShipRouteResult.GetType());
    }

    [Fact]
    public void ShouldBeSelectedPleasureShuttle()
    {
        // Arrange
        const int distance = 10;
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas(false);
        var obstacle = new Meteorite();
        var normalSpace = new NormalSpace(obstacle, 0, distance);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(normalSpace);
        var compereShips = new TwoSpaceShipsFuelCompere(spaceEnvironments);

        // Act
        ISpaceShip? result = compereShips.TwoShipsCompereCreditsSpent(vaclas, pleasureShuttle);

        // Assert
        Assert.Equal(pleasureShuttle, result);
    }

    [Fact]
    public void ShouldBeSelectedStella()
    {
        // Arrange
        const int distance = 30;
        var augur = new Augur(false);
        var stella = new Stella(false);
        var obstacle = new AntimatterFlare();
        var nebulaSpace = new NebulaSpace(obstacle, 0, distance);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(nebulaSpace);
        var compereShips = new TwoSpaceShipsFuelCompere(spaceEnvironments);

        // Act
        ISpaceShip? result = compereShips.TwoShipsCompereCreditsSpent(augur, stella);

        // Assert
        Assert.Equal(stella, result);
    }

    [Fact]
    public void ShouldBeSelectedVaclas()
    {
        // Arrange
        const int distance = 100;
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas(false);
        var obstacle = new SpaceWhale();
        var nitriteNebulaSpace = new NitriteNebulaSpace(obstacle, 0, distance);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(nitriteNebulaSpace);
        var compereShips = new TwoSpaceShipsFuelCompere(spaceEnvironments);

        // Act
        ISpaceShip? result = compereShips.TwoShipsCompereCreditsSpent(pleasureShuttle, vaclas);

        // Assert
        Assert.Equal(vaclas, result);
    }

    [Theory]
    [MemberData(nameof(SpaceShipData4))]
    public void PleasureShuttleShouldShipDistractionStellaShouldShipLossAndAugurShouldPassSuccessfully(
        ISpaceShip spaceShip,
        Results expectedSpaceShipRouteResult)
    {
        // Arrange
        const int distance = 100;
        const int obstacleAmount = 2;
        var smallMeteorite = new SmallMeteorite();
        var normalSpace = new NormalSpace(smallMeteorite, obstacleAmount, 0);
        var obstacle = new SpaceWhale();
        var nitriteNebulaSpace = new NitriteNebulaSpace(obstacle, 0, distance);
        IList<ISpaceEnvironment> spaceEnvironments = new List<ISpaceEnvironment>();
        spaceEnvironments.Add(normalSpace);
        spaceEnvironments.Add(nitriteNebulaSpace);
        var route = new Route(spaceEnvironments);

        // Act
        Results spaceShipRouteResult = route.ShipJourney(spaceShip);

        // Assert
        Assert.Equal(expectedSpaceShipRouteResult.GetType(), spaceShipRouteResult.GetType());
    }
}
