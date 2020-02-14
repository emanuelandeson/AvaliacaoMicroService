using FCamara.Application.Core;

namespace FCamara.Application.Commands.Account
{
    public class QueryAccount : Request<Response>
    {
        public QueryAccount(string accountId = null)
        {
            AccountId = accountId;
        }

        public string AccountId { get; private set; }
    }
}
