using System.Threading.Tasks;
using GateKeeper.Domain;

namespace GateKeeper.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GateKeeperDbContext context;

        public UnitOfWork(GateKeeperDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}