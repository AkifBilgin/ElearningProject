using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        // GET: InstructorAnalysis
        ELearningContext context = new ELearningContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult InstructorPanelPartial()
        {
            string value = Session["CurrentMail"].ToString();
            var values = context.Instructors.Where(x => x.Email == value).ToList();
            var v1 = context.Instructors.Where(x => x.Email == value).Select(x => x.InstructorID).FirstOrDefault();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(x => x.CourseID);
            var reviews = context.Reviews
                          .Where(c => c.Course.Instructor.InstructorID == v1).Select(x => x.ReviewScore).Average();
            ViewBag.reviews = Math.Round(reviews, 2);
            ViewBag.courseCount = context.Courses.Where(x => x.Instructor.Email == value).Count();
            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();
            return PartialView(values);
        }

        public PartialViewResult CommentPartial()
        {
            string value = Session["CurrentMail"].ToString();
            var v1 = context.Instructors.Where(x => x.Email == value).Select(x => x.InstructorID).FirstOrDefault();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(x => x.CourseID).ToList();
            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();
            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            string value = Session["CurrentMail"].ToString();
            var values = context.Courses.Where(x => x.Instructor.Email == value).ToList();
            return PartialView(values);
        }
        public PartialViewResult InstructorDescription()
        {
            string email = Session["CurrentMail"].ToString();
            var instructor = context.Instructors.Where(x => x.Email == email).ToList();
            var v1 = context.Instructors.Where(x => x.Email == email).Select(x => x.InstructorID).FirstOrDefault();
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(x => x.CourseID).ToList();
            return PartialView(instructor);
        }
        [HttpGet]
        public PartialViewResult AddVideo()
        {
            string email = Session["CurrentMail"].ToString();
            var instructor = context.Instructors.Where(x => x.Email == email).ToList();
            var v1 = context.Instructors.Where(x => x.Email == email).Select(x => x.InstructorID).FirstOrDefault();
           
            List<SelectListItem> items = (from x in context.Courses
                                          where x.InstructorID == v1
                                          select new SelectListItem
                                          {
                                              Text = x.Title,
                                              Value = x.CourseID.ToString()
                                          }).ToList();
            ViewBag.items = items;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddVideo(CourseVideo courseVideo)
        {
            string email = Session["CurrentMail"].ToString();
            var instructor = context.Instructors.Where(x => x.Email == email).ToList();
            var v1 = context.Instructors.Where(x => x.Email == email).Select(x => x.InstructorID).FirstOrDefault();

            List<SelectListItem> items = (from x in context.Courses
                                          where x.InstructorID == v1
                                          select new SelectListItem
                                          {
                                              Text = x.Title,
                                              Value = x.CourseID.ToString()
                                          }).ToList();
            ViewBag.items = items;
            context.CourseVideos.Add(courseVideo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}