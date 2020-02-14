using FCamara.Domain.Entities;
using FCamara.Domain.Contracts;
using System.Threading.Tasks;
using FCamara.Infra.Contexts;

namespace FCamara.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FCContext _context;
        public TransactionRepository(FCContext context)
        {
            _context = context;
        }
 
        public async Task<Transaction> Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
    }
}