using FCamara.Domain.Contracts;
using FCamara.Domain.Entities;
using FCamara.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCamara.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FCContext _context;
        public AccountRepository(FCContext context)
        {
            _context = context;
        }
        public async Task<Account> Add(Account account)
        {
            //var accounts = await Get();
            //accounts.Add(account);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> Get(string accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);
        }

        public async Task<IList<Account>> GetAll()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts;
        }

        public async Task<Account> Get(int accountNumber)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        }

        public async Task<Account> Update(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}
