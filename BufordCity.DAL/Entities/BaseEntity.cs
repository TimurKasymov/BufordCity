using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BufordCity.DAL.Entities
{
    /// <summary>
    /// Базовая сущность, на основании которой будут строиться все остальные
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public class BaseEntity<TType>
    {
        public TType Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}