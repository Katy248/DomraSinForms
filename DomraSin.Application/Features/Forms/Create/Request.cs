namespace DomraSin.Application.Features.Forms.Create;

public record Request(string Token, string FormName) : IRequest<Response>;