using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domen.Models;
using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommand : IRequest<Form>, IMapWith<Form>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatorId { get; set; }
}
