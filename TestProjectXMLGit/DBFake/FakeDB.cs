using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXMLGit.DataModel;

namespace TestProjectXMLGit.DBFake
{
    public class FakeDB
    {
        private List<Transaction> db = new List<Transaction>();

        public List<Transaction> GetTransactions ()
        {
            return db;
        }

        public Transaction GetSpecial (string uniqueTradeId, string executingParty)
        {
            foreach (Transaction transaction in db)
            {
                if (transaction.UniqueTradeId == uniqueTradeId && transaction.ExecutingPartyLEI == executingParty)
                    return transaction; 
            }
            return null;
        }
    }
}
