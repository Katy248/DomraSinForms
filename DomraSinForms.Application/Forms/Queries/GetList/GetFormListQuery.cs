﻿using MediatR;

namespace DomraSinForms.Application.Forms.Queries.GetList;

public class GetFormListQuery: IRequest<IEnumerable<FormDto>>
{
    public int Page { get; set; } = 0;
    public int Count { get; set; } = 10;
    public string SearchText { get; set; } = "";
}
