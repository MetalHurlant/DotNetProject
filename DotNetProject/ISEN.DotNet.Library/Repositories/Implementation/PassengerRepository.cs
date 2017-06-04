using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories.Implementation
{
    public class PassengerRepository : BaseContextRepository<Passenger>, IPassengerRepository
    {        
        public PassengerRepository(
            ILogger<PassengerRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("PassengerRepository was newed");
        }
        public override IQueryable<Passenger> EntityCollection
            => Context.PassengerCollection.AsQueryable();
    }
}