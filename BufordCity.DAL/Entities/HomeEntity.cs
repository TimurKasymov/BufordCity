using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BufordCity.DAL.Entities
{
    /// <summary>
    /// Модель дома
    /// </summary>
    public class HomeEntity : BaseEntity<int>
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не указана улица")]
        [StringLength(65)]
        public StreetEntity Street { get; set; }
        public List<PeopleEntity> Peoples { get; set; }
    }
}
