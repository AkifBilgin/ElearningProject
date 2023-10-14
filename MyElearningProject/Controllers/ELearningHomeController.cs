using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyElearningProject.DAL.Context;
namespace MyElearningProject.Controllers
{
    public class ELearningHomeController : Controller
    {
        // GET: ELearningHome
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult SpinnerPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult CarouselPartial()
        {
            var values = context.Sliders.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServicePartial()
        {
            var values = context.Widgets.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public PartialViewResult CategoriesPartial()
        {
           
            var values = context.Categories.Where(x => x.Status == true).ToList();
            var id1 = context.Categories.Where(y => y.CategoryName == "Programmierung").Select(y => y.CategoryID).FirstOrDefault();
            var count1 = context.Courses.Where(x => x.CategoryID == id1).Count();
            ViewBag.count1 = count1;
            var id2 = context.Categories.Where(y => y.CategoryName == "Englisch").Select(y => y.CategoryID).FirstOrDefault();
            var count2 = context.Courses.Where(x => x.CategoryID == id2).Count();
            ViewBag.count2 = count2;
            var id3 = context.Categories.Where(y => y.CategoryName == "Marketing").Select(y => y.CategoryID).FirstOrDefault();
            var count3 = context.Courses.Where(x => x.CategoryID == id3).Count();
            ViewBag.count3 = count3;
            var id4 = context.Categories.Where(y => y.CategoryName == "Musik").Select(y => y.CategoryID).FirstOrDefault();
            var count4 = context.Courses.Where(x => x.CategoryID == id4).Count();
            ViewBag.count4 = count4;
            return PartialView(values);
        }
        public PartialViewResult CoursesPartial()
        {
            var values = context.Courses.OrderByDescending(x => x.CourseID).Take(6).ToList();
           
     
            return PartialView(values);
        }

        public PartialViewResult TeamPartial()
        {
            var values = context.Instructors.OrderByDescending(x => x.InstructorID).Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult TestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}