using FCamara.Application.Commands.Account;
using FCamara.Application.Core;
using FCamara.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FCamara.Application.Handlers.Account
{
    public class ListAccountHandler : IRequestHandler<QueryAccount, Response>
    {
        private readonly IAccountRepository _repository;
        public ListAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(QueryAccount request, CancellationToken cancellationToken)
        {
            return new Response(await _repository.GetAll());
        }
    }
}
