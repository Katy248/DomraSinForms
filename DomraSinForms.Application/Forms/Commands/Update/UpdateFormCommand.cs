using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Commands.Update
{
    public class UpdateFormCommand: IUpdateRequest<Form>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
