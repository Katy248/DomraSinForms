﻿using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Statistics;

#nullable disable

public class QuestionSummary
{
    public QuestionBase Question { get; set; }
    public IEnumerable<string> Answers { get; set; }
}
