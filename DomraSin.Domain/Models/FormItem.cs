using System;
using DomraSin.Domain.Models;

namespace DomraSin.Domain.Models;

public class FormItem<TId> where TId : struct, FormItemId
{
    public TId Id { get; set; }
    public int Index { get; set; }
    public FormItemType Types { get; set; }
}
public readonly record struct FormItemId(Guid Value);

public enum FormItemType
{
    Question, Picture
}
