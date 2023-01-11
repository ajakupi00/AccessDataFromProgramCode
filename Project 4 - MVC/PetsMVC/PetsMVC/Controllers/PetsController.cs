using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetsMVC;

namespace PetsMVC.Controllers
{
    public class PetsController : Controller
    {
        private PPPK_MVCEntities db = new PPPK_MVCEntities();

        ~PetsController()
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.People);
            return View(pets.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pets pets = db.Pets.Find(id);
            if (pets == null)
            {
                return HttpNotFound();
            }
            return View(pets);
        }

        public ActionResult Create()
        {
            ViewBag.PersonIDPerson = new SelectList(db.People, "IDPerson", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPet,Name,PersonIDPerson")] Pets pets, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                pets.Files = new List<Files>();
                AddPictures(pets, files);

                db.Pets.Add(pets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonIDPerson = new SelectList(db.People, "IDPerson", "Name", pets.PersonIDPerson);
            return View(pets);
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Pets pet = db.Pets
                .Include(c => c.Files)
                .SingleOrDefault(c => c.IDPet == id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonIDPerson = new SelectList(db.People, "IDPerson", "Name", pet.PersonIDPerson);
            return View(pet);
        }

        private void AddPictures(Pets pets, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var picture = new Files
                    {
                        ContentType = file.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }
                    pets.Files.Add(picture);
                }
            }
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPet,Name,PersonIDPerson")] Pets pets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonIDPerson = new SelectList(db.People, "IDPerson", "Name", pets.PersonIDPerson);
            return View(pets);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pets pets = db.Pets.Find(id);
            if (pets == null)
            {
                return HttpNotFound();
            }
            return View(pets);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pets pets = db.Pets.Find(id);
            db.Pets.Remove(pets);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Owner(int id)
        {
            People person = db.People.FirstOrDefault(p => p.IDPerson == id);
            if (person == null)
                return HttpNotFound();
            return View(person.Pets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
