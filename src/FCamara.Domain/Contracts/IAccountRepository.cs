using FCamara.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCamara.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<IList<Account>> GetAll();
        Task<Account> Get(string accountId);
        Task<Account> Get(int accountNumber);
        Task<Account> Add(Account account);
        Task<Account> Update(Account account);
    }
}
