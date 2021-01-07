using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BufordCity.DAL.Entities
{
    /// <summary>
    /// Модель улицы
    /// </summary>
    public class StreetEntity : BaseEntity<int>
    {
        [Required(ErrorMessage = "Не указано название улицы")]
        public string Name { get; set; }
    }
}
