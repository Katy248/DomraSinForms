using System;

namespace DomraSinForms.Domain.Models;

public class Form
{
    public FormId Id { get; set; }
    public User Creator { get; set; }
    public IEnumerable<User> Redactors { get; set; }
    public string Name { get; set; }
    public IEnumerable<FormItem> Items { get; set; }
}

public readonly record struct FormId(Guid Value);
