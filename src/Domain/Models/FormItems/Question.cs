using System;

namespace DomraSinForms.Domain.Models.FormItems;

public class Question : FormItem
{
    public string Text { get; set; }
    public IEnumerable<QuestionOption> Options { get; set; }
    public bool IsRequired { get; set; }
}
public enum QuestionType
{
    Text,
    RichText,
    Number,
    Radio,
    Check,
    Select
}
