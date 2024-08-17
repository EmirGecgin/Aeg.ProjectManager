using Aeg.ProjectManager.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.ProjectManager.Controllers
{
    public class ProjectReportController : Controller
    {
        public AegDbContext db = new AegDbContext();
        public ActionResult DonePriorityGroup()
        {

            return View();
        }
        public ActionResult VisualizeDoneGroup()
        {
            return Json(TypeOfPriorityGroup(), JsonRequestBehavior.AllowGet);
        }
        public List<PriorityStatusAnalysis>TypeOfPriorityGroup()
        {
            ;
            List<PriorityStatusAnalysis> priorityStatusAnalysis = new List<PriorityStatusAnalysis>();
            using (var c=new AegDbContext())
                priorityStatusAnalysis = c.Projects.Where(x=>x.doneStatus==true).GroupBy(p=>p.PriorityStatus).Select(y=>new PriorityStatusAnalysis
                {
                    PriorityStatus = y.Key,
                    Count = y.Count()
                }).ToList();
            return priorityStatusAnalysis;
        }
        public ActionResult LiveSupport()
        {
            var support=db.Personels.Where(x=>x.Department=="Yazılım").ToList();
           return View(support);
        }
        public ActionResult NotDonePriorityGroup()
        {
            return View();
        }
        public ActionResult VisualizeNotDoneGroup()
        {
            return Json(TypeOfNotDonePriorityGroup(), JsonRequestBehavior.AllowGet);
        }
        public List<PriorityStatusAnalysis> TypeOfNotDonePriorityGroup()
        {
            ;
            List<PriorityStatusAnalysis> priorityStatusAnalysis = new List<PriorityStatusAnalysis>();
            using (var c = new AegDbContext())
                priorityStatusAnalysis = c.Projects.Where(x => x.doneStatus == false).GroupBy(p => p.PriorityStatus).Select(y => new PriorityStatusAnalysis
                {
                    PriorityStatus = y.Key,
                    Count = y.Count()
                }).ToList();
            return priorityStatusAnalysis;
        }
        public ActionResult GeneralProjectReportView()
        {
            return View();
        }
    }
}