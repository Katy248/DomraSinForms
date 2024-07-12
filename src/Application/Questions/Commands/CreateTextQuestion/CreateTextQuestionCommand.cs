﻿using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Questions.Commands.CreateTextQuestion;
public class CreateTextQuestionCommand : CreateQuestionBaseCommand<TextQuestion>
{
    public TextQuestionType Type { get; set; }
}
