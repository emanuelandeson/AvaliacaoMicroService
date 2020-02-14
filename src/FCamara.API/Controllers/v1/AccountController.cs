using FCamara.API.Contracts;
using FCamara.Application.Commands;
using FCamara.Application.Commands.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCamara.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        public AccountController(IMediator mediator) :
           base(mediator)
        { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostAccountRequest request)
        {
            var response = await _mediator.Send(new CreateAccount(request.Agency, request.AccountNumber, request.Amount));
            return Response(response);
        }

        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new QueryAccount());
            return Response(response);
        }

        [Route("{account}")]
        public async Task<IActionResult> GetByAccount(string account)
        {
            var response = await _mediator.Send(new QueryAccount(account));
            return Response(response);
        }
    }
}