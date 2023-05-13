namespace DomraSinForms.Application.Forms.Queries.GetList;
public class FormListDto
{
    public IEnumerable<FormDto> Forms { get; set; }
    public int PageCount { get; set; }
    public GetFormListQuery Query { get; set; }
}
