using System;
using DomraSinForms.Domain.Models;

namespace DomraSinForms.Domain.Models;

public class FormItem
{
    public FormItemId Id { get; set; }
    public int Index { get; set; }
}
public readonly record struct FormItemId(Guid Value);
