using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var tempdata = TempData["One"] = "Kurse";
            var tempdata2 = TempData["Two"] = "Index";
            var values = context.Courses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCourse()
        {
            var tempdata = TempData["One"] = "Kurse";
            var tempdata2 = TempData["Two"] = "Index";
            var tempdata3 = TempData["Three"] = "Kurse hinzufügen";
            List<SelectListItem> categories = (from x in context.Categories.ToList().OrderBy(x=>x.CategoryName)
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            List<SelectListItem> instructors = (from x in context.Instructors.ToList().OrderBy(x=>x.Name)
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.InstructorID.ToString()
                                                }).ToList();
            ViewBag.instructor = instructors;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            var tempdata = TempData["One"] = "Kurse";
            var tempdata2 = TempData["Two"] = "Index";
            var tempdata3 = TempData["Three"] = "Kurse ändern";
            List<SelectListItem> categories = (from x in context.Categories.ToList().OrderBy(x => x.CategoryName)
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.category = categories;

            List<SelectListItem> instructors = (from x in context.Instructors.ToList().OrderBy(x => x.Name)
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.InstructorID.ToString()
                                                }).ToList();
            ViewBag.instructor = instructors;
            var value = context.Courses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var update = context.Courses.Find(course.CourseID);
            update.Title = course.Title;
            update.Duration = course.Duration;
            update.ImageUrl = course.ImageUrl;
            update.InstructorID = course.InstructorID;
            update.Price = course.Price;
            update.CategoryID = course.CategoryID;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}