using FCamara.Application.Commands.Transaction;
using FCamara.Application.Core;
using FCamara.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace FCamara.Application.Handlers.Transaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransaction, Response>
    {
        private readonly ITransactionRepository _repository;
        private readonly IAccountRepository _accountRepository;
        public CreateTransactionHandler(ITransactionRepository repository, IAccountRepository accountRepository)
        {
            _repository = repository;
            _accountRepository = accountRepository;
        }
        public async Task<Response> Handle(CreateTransaction request, CancellationToken cancellationToken)
        {
            var response = new Response();

            var sourceAccount = await _accountRepository.Get(request.SourceAccount);
            var targetAccount = await _accountRepository.Get(request.TargetAccount);

            var transaction = new FCamara.Domain.Entities.Transaction(sourceAccount, targetAccount, request.Amount, request.Type);

            if (!transaction.Valid)
                response.AddNotifications(transaction.Notifications);
            else
            {
                transaction.Transference();
                if (!transaction.Valid)
                    response.AddNotifications(transaction.Notifications);
                else
                    response.AddValue(await _repository.Add(transaction));

                await updateAccounts(sourceAccount, targetAccount);
            }

            return response;
        }

        //possibilities implement messageria
        private async Task updateAccounts(FCamara.Domain.Entities.Account sourceAccount, FCamara.Domain.Entities.Account targetAccount)
        {
            await _accountRepository.Update(sourceAccount);
            await _accountRepository.Update(targetAccount);
        }
    }
}
