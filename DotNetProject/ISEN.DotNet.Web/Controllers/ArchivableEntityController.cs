using Microsoft.AspNetCore.Mvc;
using ISEN.DotNet.Library.Repositories.Interfaces;
using ISEN.DotNet.Library.Models;
using Microsoft.Extensions.Logging;
namespace ISEN.DotNet.Web.Controllers
{
    public abstract class ArchivableEntityController<T> : BaseController<IArchivableEntityRepository<T>, T>
    where T:ArchivableEntity
    {       
         public ArchivableEntityController(
            IArchivableEntityRepository<T> archivableEntityRepository,
            ILogger<ArchivableEntityController<T>> logger) : base(archivableEntityRepository, logger)
        {
        }
        [HttpGet]
        public override JsonResult All()
        {
            var model = Repository.GetAll();
            return Json(model);
        }

        public override IActionResult Index()
        {
            var model = Repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public JsonResult AllArchived()
        {
            var model = Repository.GetAll(true);
            return Json(model);
        }

        public IActionResult IndexArchived()
        {
            var model = Repository.GetAll(true);
            return View(model);
        }
    }
}
