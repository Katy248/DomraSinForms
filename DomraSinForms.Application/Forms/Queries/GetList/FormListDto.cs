using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.GetList;
public class FormListDto
{
    public IEnumerable<FormDto> Forms { get; set; }
    public int Count { get; set; }
    public int Page { get; set; }
    public int PageCount { get; set; }
    public string SearchText { get; set; }
    public string UserId { get; set; }
}
