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
    public class PersonRepository : BaseContextRepository<Person>, IPersonRepository
    {        
        public PersonRepository(
            ILogger<PersonRepository> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("PersonRepository was newed");
        }
        public override IQueryable<Person> EntityCollection
            => Context.PersonCollection.AsQueryable();
    }
}