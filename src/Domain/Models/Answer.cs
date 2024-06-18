﻿using System;
using DomraSinForms.Domain.Models.FormItems;

namespace DomraSinForms.Domain.Models;

public class Answer : EntityBase<AnswerId>
{
    public Question Question { get; set; }
    public string Value { get; set; }
}

public readonly record struct AnswerId(Guid Value);
