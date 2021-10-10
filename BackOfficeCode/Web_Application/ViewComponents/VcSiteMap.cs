using Domain.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice_Application.ViewComponents
{
    public class VcSiteMap : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string location, string entity, string text, string callback)
        {
            SiteMap siteMap = new SiteMap()
            {
                Location = location,
                Entity = entity,
                Text = text,
                Callback = callback
            };

            return View(siteMap);
        }
    }
}
