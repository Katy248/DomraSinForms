﻿using System.ComponentModel.DataAnnotations;

namespace DomraSinForms.Domen.Models;

public class DbEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
