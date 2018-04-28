using System.Threading.Tasks;

namespace GateKeeper.Domain
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

        void Complete();
    }
}