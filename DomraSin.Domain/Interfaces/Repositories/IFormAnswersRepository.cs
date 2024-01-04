﻿using DomraSin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSin.Domain.Interfaces.Repositories;

public interface IFormAnswersRepository
{
    Task<FormAnswers> Get(string id, CancellationToken cancellationToken);
    IQueryable<FormAnswers> GetCollection(string formAnswerId);
    /// <summary>
    /// Create new <see cref="FormAnswers"/>, or update existing in database.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    bool Insert(FormAnswers item, CancellationToken cancellationToken);
}
