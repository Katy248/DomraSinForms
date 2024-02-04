using DomraSin.Domain;
using DomraSin.Domain.Models;

namespace DomraSin.Application.Features.Forms.Create;

public record Response : IRequest<Result<FormId>>;