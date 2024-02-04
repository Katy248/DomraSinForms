using System;
using DomraSin.Domain.Models;

namespace DomraSin.Domain.Models;

public class FormItem<TId> where TId : struct, FormItemId
{
    public TId Id { get; set; }
    public int Index { get; set; }
    public string Descriptor { get; set; } => typeof(TId).Name;
    public bool Is<TFormItem, TId2>() where TFormItem : new(), FormItem<TId2> where TId2 : FormItemId
    {
        return this.Descriptor == typeof(TId2).Name;
    }
}
public readonly record struct FormItemId(Guid Value);