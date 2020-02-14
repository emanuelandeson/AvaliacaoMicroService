using FCamara.Domain;
using FCamara.Domain.Entities;
using Xunit;

namespace FCamara.Tests.Domain
{
    public class TransactionTests
    {
        private readonly Account _account1 = new Account(1, 1234);
        private readonly Account _account2 = new Account(1, 1235);


        [Fact]
        public void Dado_uma_transacao_entre_contas_onde_a_conta_origem_nao_possui_saldo_suficiente_as_operacoes_debto_e_credito_nao_devem_ser_realizadas()
        {
            new Transaction(_account1, _account2, 10, FCamara.Domain.Enums.ETransactionType.Transfer).Transference();
            Assert.Equal(0, _account2.Balance);
        }

        [Fact]
        public void Dado_uma_transacao_entre_contas_onde_a_conta_origem_possui_saldo_suficiente_as_operacoes_debto_e_credito_devem_ser_realizadas()
        {
            _account1.Credit(20);
            new Transaction(_account1, _account2, 10, FCamara.Domain.Enums.ETransactionType.Transfer).Transference();
            Assert.Equal(10, _account2.Balance);
        }
    }
}
