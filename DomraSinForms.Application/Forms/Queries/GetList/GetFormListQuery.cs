using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Forms.Queries.GetList;

public class GetFormListQuery : IRequest<FormListDto>
{
    public int Page { get; set; } = 0;
    public int Count { get; set; } = 10;
    public string SearchText { get; set; } = "";
    public string UserId { get; set; }
}
