using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteSpeakAndSing.Domain;
using SiteSpeakAndSing.Domain.Entities;
using SiteSpeakAndSing.Service;

namespace SiteSpeakAndSing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFildsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFildsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), (nameof(HomeController).CutController()));
            }
            return View(model);
        }
    }
}