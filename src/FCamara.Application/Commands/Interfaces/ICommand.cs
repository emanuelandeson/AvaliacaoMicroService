using FCamara.Application.Core;
using MediatR;

namespace FCamara.Application.Commands.Interfaces
{
    public interface ICommand : IRequest<Response>
    {
        void Validate();
    }
}
