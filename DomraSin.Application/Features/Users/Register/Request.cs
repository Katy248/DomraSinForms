using MediatR;

namespace DomraSin.Application.Features.Users.Register;
public record Request(string Username, string Email, string Password) : IRequest<Response>;
