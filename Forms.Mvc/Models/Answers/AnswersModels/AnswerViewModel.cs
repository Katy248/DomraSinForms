﻿using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;

namespace Forms.Mvc.Models.Answers.AnswersModels;

public class AnswerViewModel : IAnswerViewModel
{
    public AnswerViewModel(QuestionBase question, Answer answer)
    {
        Index = question.Index;
        IsRequired = question.IsRequired;
        QuestionId = question.Id;
        FormId = question.FormId;
        Question = question;
        Value = answer.Value;
    }
    public AnswerViewModel()
    {
        Index = int.MaxValue;
        IsRequired = false;
        QuestionId = "";
    }
    public string FormId { get; set; }
    public string QuestionId { get; set; }
    public int Index { get; set; }
    public bool IsRequired { get; set; }
    public virtual string Value { get; set; }
    public QuestionBase? Question { get; set; }
}
