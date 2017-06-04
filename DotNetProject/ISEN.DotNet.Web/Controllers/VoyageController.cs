using Microsoft.AspNetCore.Mvc;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ISEN.DotNet.Web.Controllers
{
    public class VoyageController : ArchivableEntityController<Voyage>
    {       
         public VoyageController(
            IVoyageRepository voyageRepository,
            ILogger<VoyageController> logger) : base(voyageRepository, logger)
        { }
        public virtual IActionResult Passenger() {
            var model = Repository.Find(v => !v.Full() && !v.Gone());
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult Driver() {
            var model = Repository.Find(v => !v.Full() && !v.Gone());
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult AdminArchived() {
            var model = Repository.Find(v => v.Archived);
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult AdminNonArchived() {
            var model = Repository.Find(v => !v.Archived);
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult DriverDateSortDown() {
            var model = Repository
                .Find(v => !v.Full() && !v.Gone())
                .OrderBy(a => a.StartTime);
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult DriverDateSortUp() {
            var model = Repository
                .Find(v => !v.Full() && !v.Gone())
                .OrderByDescending(a => a.StartTime);
            return View("~/Views/Voyage/Index.cshtml", model);
        }
        public virtual IActionResult Search() => View();

        [HttpPost]
        public virtual IActionResult SearchVoyage(Voyage booking) {
            var model = Repository
            .Find(v => !v.Full()
            && !v.Gone()
            && booking.StartTime > DateTime.Now ? v.StartTime.DayOfYear == booking.StartTime.DayOfYear : true
            && booking.StartPlace != null ? v.StartPlace.Contains(booking.StartPlace) : true
            && booking.EndPlace != null ? v.EndPlace.Contains(booking.EndPlace) : true);
            return View("~/Views/Voyage/Index.cshtml", model);
        }    
    }
}
