using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Library.Repositories.Interfaces
{
    public interface IArchivableEntityRepository<T> : IBaseRepository<T>
    	where T : ArchivableEntity
    {
    	IEnumerable<T> GetAll(bool archived);
    	IEnumerable<T> Find(
                Expression<Func<T, bool>> predicate, bool archived);
        void Archive(ArchivableEntity ae);
        void Restore(ArchivableEntity ae);
    }
}