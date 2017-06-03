using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXMLGit.DataModel
{
    public class Transaction
    {
        public ActionType Type { get; set; }
        public string UniqueTradeId { get; set; }
        public string ExecutingPartyLEI { get; set; }
        public string SubmittingPartyLEI { get; set; }
        public List<AccountOwner> AccountOwner { get; set; }
        public string ISIN { get; set; }

        public override string ToString()
        {
            string accountOwnerResult = "";
            foreach (var owner in AccountOwner)
                accountOwnerResult += owner.ToString();
            
            return Type + " | " + UniqueTradeId + " | " +
                   ExecutingPartyLEI + " | " + SubmittingPartyLEI +
                   " | (" + accountOwnerResult + ") | " + ISIN;
        }
    }
}
