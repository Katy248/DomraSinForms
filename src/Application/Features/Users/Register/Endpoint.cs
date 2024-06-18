using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;

namespace DomraSinForms.Application.Features.Users.Register;
internal class Endpoint : ICarterModule
{
    private readonly ISender _sender;

    public Endpoint(ISender sender)
    {
        _sender = sender;
    }

    public void AddRoutes(IEndpointRouteBuilder app) =>
        app.MapPost<Response>("/api/user/register", async (Request request) =>
        {
            var result = await _sender.Send(request);

            return result;
        });
}
