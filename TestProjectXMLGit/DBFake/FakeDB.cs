using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXMLGit.DataModel;

namespace TestProjectXMLGit.DBFake
{
    public static class FakeDB
    {
        private static List<Transaction> db = new List<Transaction>();

        public static List<Transaction> GetTransactions ()
        {
            return db;
        }

        public static Transaction GetSpecial (string uniqueTradeId, string executingParty)
        {
            foreach (Transaction transaction in db)
            {
                if (transaction.UniqueTradeId == uniqueTradeId && transaction.ExecutingPartyLEI == executingParty)
                    return transaction; 
            }
            return null;
        }

        public static void AddToDB (Transaction transaction)
        {
            db.Add(transaction);
        }
    }
}
