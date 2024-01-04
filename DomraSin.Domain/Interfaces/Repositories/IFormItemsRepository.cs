using DomraSin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IFormItemsRepository 
{
    Task<FormItem> Get(string id, CancellationToken cancellationToken);
    IQueryable<FormItem> GetCollection(string formId, CancellationToken cancellationToken);
    /// <summary>
    /// Create new <see cref="FormItem"/>, or update existing in database.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    bool Insert(FormItem item, CancellationToken cancellationToken);
}
