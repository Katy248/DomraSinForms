using System;

namespace DomraSinForms.Domain.Models;

public class ScoreType
{
    public ScoreTypeId Id { get; set; }
    public Form Form { get; set; }
    public string Name { get; set; }
}
public readonly record struct ScoreTypeId(Guid Value);