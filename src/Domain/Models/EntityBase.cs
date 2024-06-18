namespace DomraSinForms.Domain.Models;

public abstract class EntityBase<TId> 
{
    public TId Id { get; set; }
}