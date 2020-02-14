using Flunt.Notifications;
using MediatR;

namespace FCamara.Application.Core
{
    public abstract class Request<TResponse> : Notifiable, IRequest<TResponse>
    {

    }
}
