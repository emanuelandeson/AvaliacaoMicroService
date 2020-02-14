using FCamara.Application.Core;
using Flunt.Validations;

namespace FCamara.Application.Commands
{
    public class CreateAccount : Request<Response>
    {
        public CreateAccount(int agency, int account, decimal amount)
        {
            Validate();

            Agency = agency;
            Account = account;
            Amount = amount;
        }

        public int Agency { get; }
        public int Account { get; }
        public decimal Amount { get; }


        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsLowerOrEqualsThan(0, Amount, "Valor","Valor inválido")
            .IsLowerOrEqualsThan(0, Agency, "Agencia", "Agência inválida")
            .IsLowerOrEqualsThan(0, Account, "Conta", "Conta inválida"));
        }
    }
}
