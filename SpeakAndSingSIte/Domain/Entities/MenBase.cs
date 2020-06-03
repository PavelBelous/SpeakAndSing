using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Entities
{
    public abstract class MenBase
    {
        protected MenBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название страницы")]
        public virtual string Title { get; set; }

        [Display(Name ="Фамилия")]
        public virtual string lastName { get; set; }

        [Display(Name = "Имя")]
        public virtual string firstName { get; set; }

        [Display(Name = "Отчество")]
        public virtual string patronymic { get; set; }

        [Display(Name ="Образование")]
        public virtual string Education { get; set; }

        [Display(Name = "Стаж")]
        public virtual string Experience { get; set; }

        [Display(Name = "Полное описание педагога")]
        public virtual string Text { get; set; }

        [Display(Name = "Фото")]
        public virtual string ImagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Discription")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keyword")]
        public string MetaKeyword { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
