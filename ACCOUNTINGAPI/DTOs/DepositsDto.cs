using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACCOUNTINGAPI.DTOs
{
    public class DepositsDto

    {
      
        public int User { get; set; }
        public double Amount { get; set; }
        public DateTime Deposit_date { get; set; }

    }
}
