using System;

namespace DomraSinForms.Domain.Models;
public class FormAnswers 
{
    public FormAnswersId Id { get; set; }
    public Form Form { get; set; }
    public IEnumerable<Answer> Answers { get; set; }
    public User? User { get; set; }
}

public readonly record struct FormAnswersId(Guid Value);
