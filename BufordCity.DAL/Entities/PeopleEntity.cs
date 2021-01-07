using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BufordCity.DAL.Entities
{
    /// <summary>
    /// Модель человека
    /// </summary>
    public class PeopleEntity : BaseEntity<int>
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50)]
        public string Name {get; set;}
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50)]
        public string Surname {get; set;}
        [Required(ErrorMessage = "Не указан дом")]
        public HomeEntity Home {get; set;}
    }
}
