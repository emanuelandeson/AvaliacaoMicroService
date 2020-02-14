using Flunt.Validations;

namespace FCamara.Domain.Entities
{
    public class Account: Entity
    {
        public Account()
        {
        }
        public Account(int agency, int accountNumber, decimal amount = 0)
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterThan(accountNumber, 0, "Conta", "Conta inválida")
                .IsGreaterOrEqualsThan(accountNumber, 0, "Valor", "Valor inválido")
                .IsGreaterThan(agency, 0, "Agência", "Agência inválida"));

            AccountNumber = accountNumber;
            Agency = agency;
            Balance = amount;
        }

        public int Agency { get; private set; }
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public bool IsValid()
        {
            if (Notifications.Count > 0)
                return false;
            return true;
        }

        public void Credit(decimal amount)
        {
            if (amount <= 0)
                return;
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (Balance < amount || amount <= 0)
                return;
            Balance -= amount;
        }
    }
}
