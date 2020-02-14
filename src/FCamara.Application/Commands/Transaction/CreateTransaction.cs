using FCamara.Application.Core;
using FCamara.Domain.Enums;
using Flunt.Validations;

namespace FCamara.Application.Commands.Transaction
{
    public class CreateTransaction : Request<Response>
    {
        public CreateTransaction(string sourceAccount, string targetAccount, decimal amount)
        {
            Validate();

            SourceAccount = sourceAccount;
            TargetAccount = targetAccount;
            Amount = amount;
            Type = ETransactionType.Transfer;
        }

        public string SourceAccount { get; }
        public string TargetAccount { get; }
        public decimal Amount { get; }
        public ETransactionType Type { get; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Amount, "Agencia", "Agência inválida")
                .IsNullOrEmpty(SourceAccount, "Conta origem", "Conta origem inválida")
                .IsNullOrEmpty(SourceAccount, "Conta destino", "Conta destino inválida")
           );
        }
    }
}
