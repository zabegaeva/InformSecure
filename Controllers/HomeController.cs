using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using InformSecur.Models;
using System.Data.Entity;

namespace InformSecur.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        FileContext db = new FileContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<File> files = db.Files;
            // получаем объекты залогиненого юзера
            IEnumerable<File> userfiles = db.Files.Where(file => file.userId == "b1b41efe-5b45-4c94-8349-7c3f2b3ddf15");
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Files = files;
            // возвращаем представление
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте (сделать имя юзерid+хэш файла)
                string path = "~/Files/" + fileName;
                upload.SaveAs(Server.MapPath(path));
                
                //Добавляем путь к файлу и id user в бд
                FileContext db = new FileContext();
                db.Files.Add(new File { userId = User.Identity.GetUserId(), Name = fileName, Path = path });
                db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}