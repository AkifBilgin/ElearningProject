using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyElearningProject.DAL.Context;
namespace MyElearningProject.Controllers
{
    public class AllCoursesController : Controller
    {
        // GET: AllCourses
        ELearningContext context = new ELearningContext();
 
        public ActionResult Index()
        {
           
            return View();
        }

        public PartialViewResult Courses(int page = 0)
        {
            const int PageSize = 6;
            var count = context.Courses.Count();
            var data = context.Courses.OrderBy(x=>x.CourseID).Skip(page * PageSize).Take(PageSize).ToList();
           ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
           ViewBag.Page = page;
            return PartialView(data);
        }

        public ActionResult CourseDetails(int id)
        {
            var value = context.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            return View(value);
        }
    }
}