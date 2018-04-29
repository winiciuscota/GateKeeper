using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Queries;

namespace GateKeeper.Domain.Repositories.Interfaces
{
    public interface IResidentRepository : IRepository<Resident>
    {
        Task<IEnumerable<Resident>> GetAllAsync(ResidentQuery query);
    }
}