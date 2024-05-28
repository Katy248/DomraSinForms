using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomraSinForms.Persistence;

public class ToGuidValueConverter<T> : ValueConverter<T, Guid> where T : struct
{
    public ToGuidValueConverter(Expression<Func<T, Guid>> convertToProviderExpression, Expression<Func<Guid, T>> convertFromProviderExpression, ConverterMappingHints? mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, convertsNulls: false, mappingHints)
    {
    }
}