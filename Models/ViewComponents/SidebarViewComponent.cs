﻿using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager manager;
        public SidebarViewComponent(DataManager manager)
        {
            this.manager = manager;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", manager.ServiceItemRepository.GetServiceItem()));
        }
    }
}
