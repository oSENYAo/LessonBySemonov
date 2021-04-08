using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы(Заголовок)")]
        public override string Title { get; set; } = "Информационные системы";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "содержание заполняется только админом";

    }
}
