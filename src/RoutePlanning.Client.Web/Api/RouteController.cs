using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutePlanning.Application.Locations.Commands.CreateTwoWayConnection;
using RoutePlanning.Application.Routes.Queries.GetRoutes;
using RoutePlanning.Application.Routes.Queries.GetRoutes.Models;
using RoutePlanning.Client.Web.Authorization;

namespace RoutePlanning.Client.Web.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(nameof(TokenRequirement))]
public sealed class RoutesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IQueryable<Domain.Locations.Connection> _connections;

    public RoutesController(IMediator mediator, IQueryable<Domain.Locations.Connection> connections)
    {
        _mediator = mediator;
        _connections = connections;
    }

    [HttpGet("[action]")]
    public Task<string> HelloWorld()
    {
        return Task.FromResult("Hello World!");
    }

    [HttpPost("[action]")]
    public async Task AddTwoWayConnection(CreateTwoWayConnectionCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<RouteDetails>> GetPlaneRoutes(GetRoutesQuery command)
    {
        return await _mediator.Send(command);
    }
}
