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
    public class PassengerController : BaseController<IPassengerRepository, Passenger>
    {       
        public PassengerController(
            IPassengerRepository PassengerRepository,
            ILogger<PassengerController> logger) : base(PassengerRepository, logger)
        {
        }  
    }
}
