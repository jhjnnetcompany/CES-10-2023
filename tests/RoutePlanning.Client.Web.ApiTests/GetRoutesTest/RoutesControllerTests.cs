using MediatR;
using Moq;
using RoutePlanning.Application.Routes.Queries.GetRoutes;
using RoutePlanning.Client.Web.Api;

public class RoutesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IQueryable<RoutePlanning.Domain.Locations.Connection>> _connectionsMock;
    private readonly RoutesController _routesController;

    public RoutesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _connectionsMock = new Mock<IQueryable<RoutePlanning.Domain.Locations.Connection>>();
        _routesController = new RoutesController(_mediatorMock.Object, _connectionsMock.Object);
    }

    [Fact]
    public async Task GetPlaneRoutes_CallsMediatorWithGetRoutesQuery()
    {
        var command = new GetRoutesQuery(new List<string>() { "Weapons" }, 2, 12, 1, 18);

        await _routesController.GetPlaneRoutes(command);

        _mediatorMock.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Times.Once);
    }
}
