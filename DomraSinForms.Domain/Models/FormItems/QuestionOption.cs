using System;

namespace DomraSinForms.Domain.Models.FormItems;

public class QuestionOption
{
    public QuestionOptionId Id { get; set; }
    public string Value { get; set; }
    public ScoreType ScoreType { get; set; }
    public int Score { get; set; }
}

public readonly record struct QuestionOptionId(Guid Value);