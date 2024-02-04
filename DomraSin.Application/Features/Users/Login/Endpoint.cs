using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;

namespace DomraSin.Application.Features.Users.Login;
internal class Endpoint : ICarterModule
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }
    public void AddRoutes(IEndpointRouteBuilder app) =>
        app.MapPost<Response>("/api/user/login", async (Request request) =>
        {
            return await _sender.Send(request);
        });
}
