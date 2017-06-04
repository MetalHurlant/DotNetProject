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
    public class DriverController : BaseController<IDriverRepository, Driver>
    {       
        public DriverController(
            IDriverRepository DriverRepository,
            ILogger<DriverController> logger) : base(DriverRepository, logger)
        {
        }  
    }
}
