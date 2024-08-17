using Aeg.ProjectManager.Models.DataContext;
using Aeg.ProjectManager.Models.Personel;
using System.Linq;
using System.Web.Mvc;

namespace Aeg.ProjectManager.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        private readonly AegDbContext db;

        public AuthenticationController()
        {
            db = new AegDbContext();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Personel Model)
        {
            if (ModelState.IsValid)
            {
                var personel = db.Personels.FirstOrDefault(x => x.NameSurname == Model.NameSurname && x.password == Model.password);
                if (personel != null)
                {
                    Session["NameSurname"] = personel.NameSurname;
                    return RedirectToAction("Index", "MainPage");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
    }
}