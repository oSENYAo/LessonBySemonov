﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage ="Заполните название услуги")]
     
        [Display(Name = "Название(Заголовок)")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание услуги")]
        public override string SubTitle { get; set; }

        [Display(Name = "Полное описание услуги")]
        public override string Text { get; set; }

    }
}
