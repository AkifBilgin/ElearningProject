using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var tempdata = TempData["One"] = "Nachrichten";
            var tempdata2 = TempData["Two"] = "Index";
            var values = context.Messages.ToList();
            return View(values);
        }
        public  ActionResult ChangeStatus(int id)
        {
           var message = context.Messages.Find(id);
            if (message.IsReaden == false)
                message.IsReaden = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}