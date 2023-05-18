﻿using DomraSinForms.Application.Answers.Queries.GetList;

namespace Forms.Mvc.Models.Statistics;

#nullable disable

public class FormAnswersViewModel
{
    public string FormId { get; set; }
    public IEnumerable<FormAnswersDto> FormAnswersList { get; set; }
}
