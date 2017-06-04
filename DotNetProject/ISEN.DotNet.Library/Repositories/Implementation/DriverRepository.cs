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
    public class DriverRepository : BaseContextRepository<Driver>, IDriverRepository
    {        
        public DriverRepository(
            ILogger<DriverRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("DriverRepository was newed");
        }
        public override IQueryable<Driver> EntityCollection
            => Context.DriverCollection.AsQueryable();
    }
}