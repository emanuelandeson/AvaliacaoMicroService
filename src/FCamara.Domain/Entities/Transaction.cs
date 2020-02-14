using FCamara.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace FCamara.Domain.Entities
{
    public class Transaction : Entity
    {
        public Transaction()
        {}
        public Transaction(Account sourceAccount, Account targetAccount, decimal amount, ETransactionType type)
        {
            if (amount <= 0)
                AddNotification(new Notification("Valor", "O valor precisa ser maior que 0"));

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(sourceAccount, "ContaOrigem", "Conta origem inválida")
                    .IsNotNull(targetAccount, "ContaDestino", "Conta destino inválida")
            );

            SourceAccount = sourceAccount;
            TargetAccount = targetAccount;
            Amount = amount;
            Type = type; 
        }

        public bool IsValid()
        {
            if(Notifications.Count > 0)
                return false;
            return true;
        }

        public void Transference()
        {
            if (SourceAccount.Balance < Amount)
            {
                AddNotification(new Notification("", "Saldo insuficiente"));
                return;
            }

            SourceAccount.Debit(Amount);
            TargetAccount.Credit(Amount);
        }

        public DateTime UpdatedAt { get; set; }
        public Account SourceAccount{ get; private set; }
        public Account TargetAccount { get; private set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
    }
}
