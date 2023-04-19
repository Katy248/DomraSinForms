using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Forms.Queries.GetList
{
    public class GetFormListQueryValidator: AbstractValidator<GetFormListQuery>
    {
        public GetFormListQueryValidator()
        {
            RuleFor(q => q.Page).GreaterThanOrEqualTo(0);
            RuleFor(q => q.Count).GreaterThanOrEqualTo(0);
        }
    }
}
