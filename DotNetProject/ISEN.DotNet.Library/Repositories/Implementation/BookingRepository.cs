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
    public class BookingRepository : BaseContextRepository<Booking>, IBookingRepository
    {        
        public BookingRepository(
            ILogger<BookingRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("BookingRepository was newed");
        }
        public override IQueryable<Booking> EntityCollection
            => Context.BookingCollection.AsQueryable();
        public override IQueryable<Booking> Includes(IQueryable<Booking> queryable) {
            queryable = base.Includes(queryable);
            queryable = queryable.Include(b => b.Passenger);
            queryable = queryable.Include(b => b.Voyage);
            queryable = queryable.Include(b => b.Voyage.Driver);
            return queryable;
        }
    }
}