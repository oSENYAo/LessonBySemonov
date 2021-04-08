using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager manager;
        public TextFieldsController(DataManager manager)
        {
            this.manager = manager;
        }

        public IActionResult Edit(string CodeWord)
        {
            var entity = manager.TextFieldsRepository.GetTextFieldByCodeWord(CodeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                manager.TextFieldsRepository.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

    }
}
