using FCamara.Domain.Entities;
using System.Threading.Tasks;

namespace FCamara.Domain.Contracts
{
    public interface ITransactionRepository
    {
        Task<Transaction> Add(Transaction transaction);
    }
}
