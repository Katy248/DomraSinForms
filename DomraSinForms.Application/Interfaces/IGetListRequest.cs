using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Mapper;
using MediatR;

namespace DomraSinForms.Application.Interfaces;
public interface IGetListRequest<TEntity> : IRequest<IEnumerable<IMapWith<TEntity>>> 
{
    public int Page { get; set; }
    public int Count { get; set; }
    public string SearchText { get; set; }
}
