using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Entities
{
    public class Teacher : MenBase
    {
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы")]
        public override string Title { get; set; } = "Информация о педогоге";

        [Display(Name = "Образование")]
        public override string Education { get; set; } = "Заполняется администратором";

        [Display(Name = "Стаж")]
        public override string Experience { get; set; }

        [Display(Name = "Полное описание педагога")]
        public override string Text { get; set; } = "Заполняется администратором";
    }
}
