﻿using DomraSinForms.Application.Interfaces;

namespace DomraSinForms.Application.Forms.Commands.Delete;

public class DeleteFormCommand : IDeleteRequest
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
