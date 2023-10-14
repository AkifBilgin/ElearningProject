using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
          
                string value = Session["CurrentMail"].ToString();
                ViewBag.mail = value;
                var student = context.Students.Where(x => x.Email == value).FirstOrDefault();
                ViewBag.name = context.Students.Where(x => x.Email == value).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
                return View(student);
            
         
            
           
            
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            string value = Session["CurrentMail"].ToString();
            ViewBag.mail = value;
            var email = context.Students.Where(x => x.Email == value).FirstOrDefault();
            ViewBag.name = context.Students.Where(x => x.Email == value).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            var update = context.Students.Find(student.StudentID);
            update.Name = student.Name;
            update.Surname = student.Surname;
            update.Email = student.Email;
            update.Password = student.Password;
            context.SaveChanges();
            return View(update);
        }
        [HttpGet]
        public ActionResult MyCourseList()
        {
            string email = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == email).Select(y => y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }


       
        public ActionResult CourseVideo(int id)
        {
            var value = context.CourseVideos.Where(x => x.CourseID == id).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Review()
        {
            string email = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == email).Select(y => y.StudentID).FirstOrDefault();
            var course = context.Courses
                              .Where(c => c.Processes.Any(p => p.StudentID == id))
                              .ToList();
          

            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            return View();  
        }

        [HttpPost]
        public ActionResult Review(Review review)
        {
            string email = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == email).Select(y => y.StudentID).FirstOrDefault();
            review.StudentID = id;
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("MyCourseList");
        }

        [HttpGet]
        public ActionResult Comments()
        {
            string email = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == email).Select(y => y.StudentID).FirstOrDefault();
            var course = context.Courses
                              .Where(c => c.Processes.Any(p => p.StudentID == id))
                              .ToList();


            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            return View();
        }

        [HttpPost]
        public ActionResult Comments(Comment comment)
        {
            string email = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x => x.Email == email).Select(y => y.StudentID).FirstOrDefault();
            comment.StudentID = id;
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            context.Comments.Add(comment);
            context.SaveChanges();
            return RedirectToAction("MyCourseList");
        }
    }
}