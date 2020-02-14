using System;

namespace FCamara.API.Contracts
{
    public class PostTransactionRequest
    {
        /// <summary>
        /// Conta de origem
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Conta de destino
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Valor a ser transferido
        /// </summary>
        public decimal Value { get; set; }
    }
}
