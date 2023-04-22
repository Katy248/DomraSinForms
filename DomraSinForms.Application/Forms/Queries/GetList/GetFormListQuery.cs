using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domen.Models;

namespace DomraSinForms.Application.Forms.Queries.GetList;

public class GetFormListQuery : IGetListRequest<Form>
{
    public int Page { get; set; } = 0;
    public int Count { get; set; } = 10;
    public string SearchText { get; set; } = "";
}
