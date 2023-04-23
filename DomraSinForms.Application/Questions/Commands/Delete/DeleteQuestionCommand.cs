using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;

namespace DomraSinForms.Application.Questions.Commands.Delete;
public class DeleteQuestionCommand : IDeleteRequest
{
    public string Id { get; set; }
}
