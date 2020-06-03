using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required(ErrorMessage ="CodeWord обязательно к заполнению")]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = ("Содержание страницы"))]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
