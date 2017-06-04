using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;
using Microsoft.Extensions.Logging;
using ISEN.DotNet.Library.Data;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ISEN.DotNet.Web.Controllers
{
    public class BookingController : BaseController<IBookingRepository, Booking>
    {       
        private IVoyageRepository voyageRepository;
        public BookingController(
            IBookingRepository BookingRepository,
            IVoyageRepository VoyageRepository,
            ILogger<BookingController> logger) : base(BookingRepository, logger)
        {
            voyageRepository = VoyageRepository;
        }

        public override IActionResult Detail(int? id){
        	if (id == null) return RedirectToAction("Driver", "Voyage");          
            var model = new Booking();
            model.VoyageId = id.Value;
            return View(model);
        }
        [HttpPost]
        public override IActionResult Detail(Booking Booking)
        {
            Logger.LogWarning(Booking.VoyageId.ToString());
            var voyage = voyageRepository.Single(Booking.VoyageId ?? default(int));
            voyage.RemainingSeat--;
            voyageRepository.Update(voyage);
            voyageRepository.Save();
            Repository.Update(Booking);
            Repository.Save();
            return RedirectToAction("Index");
        }
    }
}
