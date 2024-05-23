using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DomraSinForms.Application.Extensions;
public static class ValidationExtensions
{
    public static async ValueTask<bool> ValidateMany<T>(this IEnumerable<IValidator<T>> validators, T context, CancellationToken cancellationToken)
    {
        foreach (var validator in validators)
        {
            var validationResult = await validator.ValidateAsync(context, cancellationToken);
            if (!validationResult.IsValid)
                return false;
        }

        return true;
    }
}
