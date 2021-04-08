using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager manager;
        public ServicesController(DataManager manager)
        {
            this.manager = manager;
        }
        public ActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", manager.ServiceItemRepository.GetServiceItemById(id));
            }
            ViewBag.TextField = manager.TextFieldsRepository.GetTextFieldByCodeWord("PageServices");
            return View(manager.ServiceItemRepository.GetServiceItem());
        }

    }
}
