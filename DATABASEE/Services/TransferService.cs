using System.Collections.Generic;
using DATABASEE.Models;

namespace DATABASEE.Services
{
    public class TransferService
    {
        private List<Transfers> transfers = new List<Transfers>();

        public List<Transfers> GetAllTransfers()
        {
            return transfers;
        }

        public void AddTransfer(Transfers transfer)
        {
            transfers.Add(transfer);
        }
    }
}
