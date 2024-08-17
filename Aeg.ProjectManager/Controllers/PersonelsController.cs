using Aeg.ProjectManager.Models.DataContext;
using Aeg.ProjectManager.Models.Personel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Aeg.ProjectManager.Controllers
{
    public class PersonelsController : Controller
    {
        private AegDbContext db = new AegDbContext();

        
        public ActionResult Index()
        {
            return View(db.Personels.ToList());
        }
        public ActionResult PersonelContact()
        {
            return View(db.Personels.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;//: Bu satır, veritabanındaki mevcut Personel kaydının güncellenmesi gerektiğini belirtir. EntityState.Modified, EF (Entity Framework)'e bu varlığın (entity) değiştirilmiş olduğunu ve güncellenmesi gerektiğini söyler.
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null||id==0)
            {
                return HttpNotFound();
            }
            Personel personel = db.Personels.Find(id);
            db.Personels.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
