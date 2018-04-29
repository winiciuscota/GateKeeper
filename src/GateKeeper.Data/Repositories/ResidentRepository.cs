using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GateKeeper.Data.Context;
using GateKeeper.Data.Repository;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Queries;
using GateKeeper.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GateKeeper.Data.Repositories
{
    public class ResidentRepository : Repository<Resident>, IResidentRepository
    {
        public ResidentRepository(GateKeeperDbContext dbContext) : base(dbContext)
        { }

        public async Task<IEnumerable<Resident>> GetAllAsync(ResidentQuery queryFilter)
        {
            var query = _dbContext.Set<Resident>().AsQueryable();

            if (!string.IsNullOrEmpty(queryFilter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(queryFilter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryFilter.Email))
            {
                query = query.Where(x => x.Email.Contains(queryFilter.Email));
            }

            if (!string.IsNullOrEmpty(queryFilter.Apartment))
            {
                query = query.Where(x => x.Apartment.Contains(queryFilter.Apartment));
            }

            if (!string.IsNullOrEmpty(queryFilter.Block))
            {
                query = query.Where(x => x.Block.Contains(queryFilter.Block));
            }

            return await query.ToListAsync();
        }
    }
}