﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.Update;
public class UpdateOptionsCommand : IUpdateRequest<OptionsQuestion>
{
    public string Id { get; set; }
    public ICollection<QuestionOption> Options { get; set; }
}
