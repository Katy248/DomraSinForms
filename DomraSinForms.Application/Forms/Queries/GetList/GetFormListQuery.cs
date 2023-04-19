using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.GetList;

public class GetFormListQuery: IRequest<IEnumerable<FormDto>>
{
    public int Page { get; set; } = 0;
    public int Count { get; set; } = 10;
    public string SearchText { get; set; } = "";
}
