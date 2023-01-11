using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsMVC.Controllers
{
    public class FileController : Controller
    {
        private readonly PPPK_MVCEntities db = new PPPK_MVCEntities();

        ~FileController()
        {
            db.Dispose();
        }

        // GET: Picture
        public ActionResult Index(int id)
        {
            var picture = db.Files.Find(id);
            return File(picture.Content, picture.ContentType);
        }

        public ActionResult Delete(int id)
        {
            db.Files.Remove(db.Files.Find(id));
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}