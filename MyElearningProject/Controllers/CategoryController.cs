using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            var tempdata = TempData["One"] = "Kategorie";
            var tempdata2 = TempData["Two"] = "Index";

            var values = context.Categories.ToList();

            return View(values);
        }
        public ActionResult ChangeStatus(int id)
        {
            var tempdata = TempData["One"] = "Kategorie";
            var tempdata2 = TempData["Two"] = "Index";

            var values = context.Categories.Find(id);
            if (values.Status == true)
            {
                values.Status = false;
                context.SaveChanges();
            }
            else
            {
                values.Status = true;
                context.SaveChanges();
            }
                
            return RedirectToAction("Index", values.Status);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            var tempdata = TempData["One"] = "Kategorie";
            var tempdata2 = TempData["Two"] = "Index";
            var tempdata3 = TempData["Three"] = "Kategorie hinzufügen";
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var tempdata = TempData["One"] = "Kategorie";
            var tempdata2 = TempData["Two"] = "Index";
            var tempdata3 = TempData["Three"] = "Kategorie ändern";
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}