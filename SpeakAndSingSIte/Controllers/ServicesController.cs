 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteSpeakAndSing.Domain;

namespace SiteSpeakAndSing.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager dataManager;
        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if(id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemsById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageService");
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}