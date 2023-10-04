
namespace ACCOUNTINGAPI.DTOs
{
    public class TransfersDto
    {

        public string Username { get; set; }

        public int Sender_account { get; set; }

        
        public int Receiver_account { get; set; }

        
        public double Amount { get; set; }

    }
}
