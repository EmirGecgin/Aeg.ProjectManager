using Aeg.ProjectManager.Models.DataContext;
using Aeg.ProjectManager.Models.Project;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Aeg.ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        private AegDbContext db = new AegDbContext();
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Id=new SelectList(db.Personels, "Id", "NameSurname");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Project project, int[]Id)
        {
            foreach (var item in Id)
            {
                project.Personels.Add(db.Personels.Find(item));
            }
            project.CreatedDate = DateTime.Now;
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)//Kullanıcıya göre düzenleme yapılacak
        {
            var project = db.Projects.Find(Id);
            return View(project);
        }
        [HttpPost]
        public ActionResult Edit(Project project)//Kullanıcıya göre düzenleme yapılacak
        {
            var projectToUpdate = db.Projects.Find(project.Id);
            projectToUpdate.ProjectDescription = project.ProjectDescription;
            projectToUpdate.ProjectName = project.ProjectName;
            projectToUpdate.DoneRatio = project.DoneRatio;
            projectToUpdate.PriorityStatus = project.PriorityStatus;
            projectToUpdate.DoneDate = project.DoneDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DoneProject(int Id)
        {
            var project = db.Projects.Find(Id);
            project.doneStatus = true;
            project.DoneRatio= 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}