using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ISEN.DotNet.Library.Models;

namespace ISEN.DotNet.Library.Repositories.Interfaces
{
    public interface IVoyageRepository: IArchivableEntityRepository<Voyage> {
        IEnumerable<Voyage> GetAll(Passenger Passenger);
    }
}