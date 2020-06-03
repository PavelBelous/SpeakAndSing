using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiteSpeakAndSing.Domain;

namespace SiteSpeakAndSing.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataManager dataManager;
        public TeacherController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index(Guid id)
        {
            if(id != default)
            {
                ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageTeachers");
                return View("Show1", dataManager.Teachers.GetTeacherById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageTeachers");
            return View(dataManager.Teachers.GetTeachers());
        }
    }
}