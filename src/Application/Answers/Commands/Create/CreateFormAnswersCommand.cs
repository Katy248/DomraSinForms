﻿using DomraSinForms.Domain.Models.Answers;
using MediatR;

namespace DomraSinForms.Application.Answers.Commands.Create;

public class CreateFormAnswersCommand : IRequest<FormAnswers?>
{
    public string UserId { get; set; } = "";
    public string FormId { get; set; } = "";
}
