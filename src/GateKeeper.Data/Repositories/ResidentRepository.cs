using GateKeeper.Data.Context;
using GateKeeper.Data.Repository;
using GateKeeper.Domain.Entities;
using GateKeeper.Domain.Repositories.Interfaces;

namespace GateKeeper.Data.Repositories
{
    public class ResidentRepository : Repository<Resident>, IResidentRepository
    {
        public ResidentRepository(GateKeeperDbContext dbContext) : base(dbContext)
        { }
    }
}