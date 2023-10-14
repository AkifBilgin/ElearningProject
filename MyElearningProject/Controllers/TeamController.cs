using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Instructors.ToList();
            return View(values);
        }
    }
}