using Aeg.ProjectManager.Models.DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aeg.ProjectManager.Controllers
{
    public class MainPageController : Controller
    {
        private AegDbContext db = new AegDbContext();

        // GET: MainPage
        public ActionResult Index()
        {

            if (Session["NameSurname"] != null)
            {
                ViewBag.NameSurname = Session["NameSurname"].ToString();
            }
            else
            {
                // Eğer oturum açılmamışsa giriş sayfasına yönlendirin
                return RedirectToAction("Login", "Authentication");
            }
            int projectCount = db.Projects.Count();
            ViewBag.ProjectCount = projectCount;
            int doneProjectCount = db.Projects.Where(x => x.doneStatus == true).Count();
            ViewBag.DoneProjectCount = doneProjectCount;
            var highPriorityProjectCount = db.Projects.Where(x => x.PriorityStatus == "Yüksek Öncelikli").Count();
            ViewBag.HighPriorityProjectCount = highPriorityProjectCount;
            var mediumPriorityProjectCount = db.Projects.Where(x => x.PriorityStatus == "Orta Öncelikli").Count();
            ViewBag.MediumPriorityProjectCount = mediumPriorityProjectCount;
            var lowPriorityProjectCount = db.Projects.Where(x => x.PriorityStatus == "Düşük Öncelikli").Count();
            ViewBag.LowPriorityProjectCount = lowPriorityProjectCount;
            var doneAndHighPriorityProjectCount = db.Projects.Where(x => x.doneStatus == true).Where(x => x.PriorityStatus == "Yüksek Öncelikli").Count();
            ViewBag.DoneAndHighPriorityProjectCount = doneAndHighPriorityProjectCount;
            var doneAndMediumPriorityProjectCount = db.Projects.Where(x => x.doneStatus == true).Where(x => x.PriorityStatus == "Orta Öncelikli").Count();
            ViewBag.DoneAndMediumPriorityProjectCount = doneAndMediumPriorityProjectCount;
            var doneAndLowPriorityProjectCount = db.Projects.Where(x => x.doneStatus == true).Where(x => x.PriorityStatus == "Düşük Öncelikli").Count();
            ViewBag.DoneAndLowPriorityProjectCount = doneAndLowPriorityProjectCount;
            var notDoneProjectCount = db.Projects.Where(x => x.doneStatus == false).Count();
            ViewBag.NotDoneProjectCount = notDoneProjectCount;

            var personels = db.Personels.ToList();
            var doneProjectsByPersonel = new Dictionary<int, int>();//personelin id si ve proje sayısını tutacak
            foreach (var personel in personels)
            {
                int doneProjectCountByPersonel = 0;
                foreach (var project in personel.Projects)
                {
                    if (project.doneStatus == true)
                    {
                        doneProjectCountByPersonel++;
                    }
                }
                doneProjectsByPersonel[personel.Id] = doneProjectCountByPersonel;
            }

            var listPersonelProject = doneProjectsByPersonel.OrderByDescending(x => x.Value);
            var theMostHardworkestPersonelId = listPersonelProject.First().Key;
            var theMostHardworkestPersonel = db.Personels.FirstOrDefault(x => x.Id == theMostHardworkestPersonelId);
            ViewBag.TheMostHardworkestPersonelNameSurname = theMostHardworkestPersonel.NameSurname;

            var theMostHardworkestPersonelProjectCount = doneProjectsByPersonel[theMostHardworkestPersonelId];
            ViewBag.TheMostHardworkestPersonelProjectCount = theMostHardworkestPersonelProjectCount;

            return View();
        }
        public ActionResult GeneralStatistic()
        {
            int projectCount = db.Projects.Count();
            ViewBag.ProjectCount = projectCount;
            int personelCount=db.Personels.Count();
            ViewBag.PersonelCount=personelCount;
            int totalDoneProject = db.Projects.Where(x => x.doneStatus == true).Count();
            ViewBag.TotalDoneProject = totalDoneProject;
            int totalNotDoneProject = db.Projects.Where(x => x.doneStatus == false).Count();
            ViewBag.TotalNotDoneProject = totalNotDoneProject;
            int totalNotDoneHighestPriorityProject=db.Projects.Where(x=>x.PriorityStatus=="Yüksek Öncelikli").Where(x=>x.doneStatus==false).Count();
            ViewBag.TotalNotDoneHighestPriorityProject= totalNotDoneHighestPriorityProject;
            int totalNotDoneMediumPriorityProject = db.Projects.Where(x => x.PriorityStatus == "Orta Öncelikli").Where(x => x.doneStatus == false).Count();
            ViewBag.TotalNotDoneMediumPriorityProject = totalNotDoneMediumPriorityProject;

            var personels= db.Personels.ToList();
            var personelProjects= db.Projects.ToList();
            var doneProjectsCount= new Dictionary<int, int>();
            var notDoneProjectsCount=new Dictionary<int, int>();
            var totalProjectCount= new Dictionary<int, int>();
            foreach(var personel in personels)
            {
                int doneCounter = 0;
                int notDoneCounter = 0;
                int totalCounter = 0;
                foreach(var project in personelProjects)
                {
                    if (project.Personels.Contains(personel))
                    {
                        totalCounter++;
                        if (project.doneStatus)
                        {
                            doneCounter++;
                        }
                        else
                        {
                            notDoneCounter++;
                        }
                    }
                }
                doneProjectsCount[personel.Id] = doneCounter;
                totalProjectCount[personel.Id]=totalCounter;
                notDoneProjectsCount[personel.Id]=notDoneCounter;
            }
            ViewBag.TotalProjectCount = totalProjectCount;
            ViewBag.DoneProjectsCount = doneProjectsCount;
            ViewBag.NotDoneProjectsCount = notDoneProjectsCount;
            return View(personels);
        }
    }
}