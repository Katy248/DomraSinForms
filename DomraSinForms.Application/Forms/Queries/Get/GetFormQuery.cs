﻿using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domen.Models;

namespace DomraSinForms.Application.Forms.Queries.Get;

public class GetFormQuery : IGetSingleRequest<Form>
{
    public string Id { get; set; }
}
