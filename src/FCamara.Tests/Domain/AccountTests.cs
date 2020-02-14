using FCamara.Domain.Entities;
using Xunit;

namespace FCamara.Tests.Domain
{
    public class AccountTests
    {
        private readonly Account _account = new Account(1,1234);

        [Fact]
        public void dada_uma_conta_valida_deve_retornar_true()
        {
            var account = new Account(1, 1234);
            Assert.True(account.IsValid());
        }

        [Fact]
        public void dada_uma_conta_com_agencia_invalida_deve_retornar_false()
        {
            var account = new Account(0, 1234);
            Assert.False(account.IsValid());
        }

        [Fact]
        public void dada_uma_conta_com_numero_conta_invalido_deve_retornar_false()
        {
            var account = new Account(1, 0);
            Assert.False(account.IsValid());
        }

        [Fact]
        public void dada_um_debto_em_conta_com_valor_superior_a_0_o_mesmo_deve_ser_realizado()
        {
            _account.Credit(20);
            _account.Debit(10);
            Assert.Equal(10, _account.Balance, 2);
        }

        [Fact]
        public void dada_um_debto_em_conta_com_valor_superior_ao_saldo_o_mesmo_nao_deve_ser_realizado()
        {
            _account.Debit(10);
            Assert.Equal(0,_account.Balance,2);
        }

        [Fact]
        public void dada_um_debto_em_conta_com_valor_inferior_a_0_o_mesmo_nao_deve_ser_realizado()
        {
            _account.Debit(-1);
            Assert.Equal(0, _account.Balance, 2);
        }

        [Fact]
        public void dada_um_credito_em_conta_com_valor_inferior_a_0_o_mesmo_nao_deve_ser_realizado()
        {
            _account.Credit(-1);
            Assert.Equal(0, _account.Balance, 2);
        }

        [Fact]
        public void dada_um_credito_em_conta_com_valor_superior_a_0_o_mesmo_deve_ser_realizado()
        {
            _account.Credit(10);
            Assert.Equal(10, _account.Balance, 2);
        }
    }
}
