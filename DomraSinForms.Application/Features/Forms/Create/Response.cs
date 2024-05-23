using DomraSinForms.Domain;
using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Features.Forms.Create;

public record Response : IRequest<Result<FormId>>;