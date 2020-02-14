using FCamara.Application.Commands;
using FCamara.Application.Core;
using FCamara.Domain.Contracts;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FCamara.Application.Handlers.Account
{
    public class CreateAccountHandler : IRequestHandler<CreateAccount, Response>
    {
        private readonly IAccountRepository _repository;
        public CreateAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var account = new Domain.Entities.Account(request.Agency, request.Account, request.Amount);

            if (!account.Valid)
                response.AddNotifications(account.Notifications);
            else
            {
                var exists = await _repository.Get(request.Account);
                if (exists == null)
                    response.AddValue(await _repository.Add(account));
                else
                    response.AddNotification(new Notification("Conta", "Conta já cadastrada"));
            }

            return response;
        }
    }
}
