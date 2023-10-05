using RoutePlanning.Domain.Locations;
using RoutePlanning.Domain.Locations.Services;

namespace RoutePlanning.Domain.UnitTests.Routing;

public sealed class PathTest
{
    [Fact]
    public void ShortestPathTest()
    {
        // Arrange
        var locationA = new Location("A");
        var locationB = new Location("B");
        var locationC = new Location("C");

        locationA.AddConnection(locationB, 2, 4, new Company("a"));
        locationB.AddConnection(locationC, 3, 5, new Company("b"));
        locationA.AddConnection(locationC, 6, 7, new Company("c"));

        var locations = new List<Location> { locationA, locationB, locationC };

        var shortestDistanceService = new ShortestDistanceService(locations.AsQueryable());

        // Act
        var distance = shortestDistanceService.GetShortestDistance(locationA, locationC);

        // Assert
        Assert.Equal(5, distance.Sum(x => x.TimeInHours));
    }
}
