﻿namespace DomraSinForms.Domain.Models.Questions;
public class TextQuestion : QuestionBase
{
    public TextQuestionType Type { get; set; }
}
public enum TextQuestionType
{
    Text = 0,
    Number = 1,
    Date = 2,
    Time = 3,
    DateTime = 4,
    PhoneNumber = 5,
}