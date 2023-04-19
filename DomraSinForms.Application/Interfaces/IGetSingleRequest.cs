using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSinForms.Application.Interfaces;
public interface IGetSingleRequest<TEntity> : IRequest<TEntity>
{
    public string Id { get; set; }
}
