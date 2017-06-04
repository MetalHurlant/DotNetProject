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
    public abstract class ArchivableEntityRepository<T> : BaseContextRepository<T>, IArchivableEntityRepository<T>
        where T : ArchivableEntity
    {        
        public ArchivableEntityRepository(
            ILogger<ArchivableEntityRepository<T>> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogWarning("ArchivableRepository was newed");
        }
        public override IEnumerable<T> GetAll() {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            queryable = queryable.Where(p => p.Archived == false);
            return queryable;
        }
        public IEnumerable<T> GetAll(bool archived) {
            if(!archived){
                return GetAll();
            } else {
                var queryable = EntityCollection;
                queryable = Includes(queryable);
                queryable = queryable.Where(a => a.Archived == true);
                return queryable;
            }
        }
        public override IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
            var queryable = EntityCollection;
            queryable = Includes(queryable);
            queryable = queryable.Where(a => a.Archived == false);
            queryable = queryable.Where(predicate);
            return queryable;
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, bool archived) {
                var queryable = EntityCollection;
                queryable = Includes(queryable);
                queryable = queryable.Where(a => a.Archived == archived);
                queryable = queryable.Where(predicate);
                return queryable;
        }
        public void Archive(ArchivableEntity ae) {
            ae.Archive();
        }
        public void Restore(ArchivableEntity ae) {
            ae.Restore();
        }
    }
}