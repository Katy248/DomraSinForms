using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Commands.Delete
{
    public class DeleteFormCommand : IDeleteRequest
    {
        public string Id { get; set; }
    }
}
