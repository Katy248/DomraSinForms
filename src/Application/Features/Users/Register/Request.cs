using MediatR;

namespace DomraSinForms.Application.Features.Users.Register;
public record Request(string Username, string Email, string Password) : IRequest<Response?>;
