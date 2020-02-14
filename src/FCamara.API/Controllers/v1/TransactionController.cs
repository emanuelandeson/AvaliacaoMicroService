using FCamara.API.Contracts;
using FCamara.Application.Commands.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCamara.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ApiController
    {
        public TransactionController(IMediator mediator):
            base(mediator)
        {}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostTransactionRequest request)
        {
            var response = await _mediator.Send(new CreateTransaction(request.From, request.To, request.Value));
            return Response(response);
        }
    }
}