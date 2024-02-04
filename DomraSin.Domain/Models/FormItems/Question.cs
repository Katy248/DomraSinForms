using System;

namespace DomraSin.Domain.Models;

public class Question : FormItem<QuestionId>
{
    public Question() => this.Type = FormItemType.Question;
    public Form Form { get; set; }
    public string Text { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }
    public bool IsRequired { get; set; }
}
public readonly record struct QuestionId : FormItemId;
public enum QuestionType
{
    Text,
    RichText,
    Number,
    Radio,
    Check,
    Select
}
