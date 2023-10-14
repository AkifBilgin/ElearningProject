using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyElearningProject.DAL.Context;
namespace MyElearningProject.Controllers
{
    public class InstructorLoginController : Controller
    {
        // GET: InstructorLogin
        ELearningContext context = new ELearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Instructor instructor)
        {
            var values = context.Instructors.FirstOrDefault(x => x.Email == instructor.Email && x.Password == instructor.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            
            return View();
        }
    }
}