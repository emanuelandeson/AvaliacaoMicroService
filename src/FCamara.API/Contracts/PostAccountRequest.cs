namespace FCamara.API.Contracts
{
    public class PostAccountRequest
    {
        public int Agency { get;   set; }
        public int AccountNumber { get;   set; }
        public decimal Amount { get;   set; }
    }
}
