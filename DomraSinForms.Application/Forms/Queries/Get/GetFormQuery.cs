using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models;

namespace DomraSinForms.Application.Forms.Queries.Get;

public class GetFormQuery : IGetSingleRequest<Form>
{
    public string Id { get; set; }
    public string UserId { get; set; }
}
