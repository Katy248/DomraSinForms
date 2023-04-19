using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domen.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.Get;

public class GetFormQuery: IGetSingleRequest<Form>
{
    public string Id { get; set; }
}
