using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Data;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Repositories.Implementation
{
    public class VoyageRepository : ArchivableEntityRepository<Voyage>, IVoyageRepository
    {        
        public VoyageRepository(
            ILogger<VoyageRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("VoyageRepository was newed");
        }
        public override IQueryable<Voyage> EntityCollection
            => Context.VoyageCollection.AsQueryable();
        public IEnumerable<Voyage> GetAll(Passenger Passenger) {
            return Passenger.Voyages;
        }
        public override IQueryable<Voyage> Includes(IQueryable<Voyage> queryable) {
            queryable = base.Includes(queryable);
            queryable = queryable.Include(e => e.Driver);
            return queryable;
        }
    }
}