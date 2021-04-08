using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.Areas.Admin.Controllers;
namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager manager;
        private readonly IWebHostEnvironment hostingEnvironment;
        
        public ServiceItemsController(DataManager manager, IWebHostEnvironment hostingEnvironment)
        {
            this.manager = manager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ServiceItem() : manager.ServiceItemRepository.GetServiceItemById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                    manager.ServiceItemRepository.SaveServiceItem(model);
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                }
            }
            return View(model);
        }
        
        
        
        
        
        
        
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            manager.ServiceItemRepository.DeleteServiceItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
