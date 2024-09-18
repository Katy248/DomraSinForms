using MediatR;

namespace DomraSinForms.Application.Features.Forms.Create;

internal sealed class Handler : IRequestHandler<Request, Response>
{
  public Task<Response> Handle(Request request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException()
  }
}
