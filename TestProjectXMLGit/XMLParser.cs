using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TestProjectXMLGit.DataModel;

namespace TestProjectXMLGit
{
    public class XMLParser
    {
        private XDocument parse; 

        public XMLParser (string fileName)
        {
            try
            {
                parse = XDocument.Load(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var transactions = parse.Descendants("transaction");
            foreach (var transaction in transactions)
            {
                Transaction transactionToDB = new Transaction();
                if (transaction.HasElements &&
                    transaction.Element("type") != null &&
                    transaction.Element("type").Value.Equals("New"))
                {
                    transactionToDB.Type = ActionType.New;
                    transactionToDB.UniqueTradeId = transaction.Element("id")?.Value;
                    transactionToDB.ExecutingPartyLEI = transaction.Element("Executing")?.Value;
                    transactionToDB.SubmittingPartyLEI = transaction.Element("Submitting")?.Value;
                    var accountOwners = transaction.Elements("AccntOwnr");
                    if (accountOwners != null)
                    {
                        List<AccountOwner> accountOwnerToDB = new List<AccountOwner>();
                        foreach (var accountOwner in accountOwners)
                        {
                            AccountOwner owner = new AccountOwner();
                            if (accountOwner.HasElements)
                            {
                                if (accountOwner.Element("Person") != null)
                                {
                                    owner.Type = IdType.Person;
                                    Person personToDB = new Person();
                                    var person = accountOwner.Element("Person");
                                    personToDB.FirstName = person.Element("FNme")?.Value;
                                    personToDB.Name = person.Element("Nme")?.Value;
                                    if (person.Element("BrthDte") != null)
                                        personToDB.DateOfBirth = DateTime.Parse(person.Element("BrthDte").Value);
                                    owner.Person = personToDB;
                                }
                                else if (accountOwner.Element("LEI") != null)
                                {
                                    owner.Type = IdType.LEI;
                                    owner.Id = accountOwner.Element("LEI").Value;
                                }
                                else if (accountOwner.Element("MIC") != null)
                                {
                                    owner.Type = IdType.MIC;
                                    owner.Id = accountOwner.Element("MIC").Value;
                                }
                            }
                            accountOwnerToDB.Add(owner);
                        }
                        transactionToDB.AccountOwner = accountOwnerToDB;
                    }
                    transactionToDB.ISIN = transaction.Element("ISIN")?.Value;
                }
                else if (transaction.HasElements &&
                         transaction.Element("type") != null &&
                         transaction.Element("type").Value.Equals("Cx"))
                {
                    transactionToDB.Type = ActionType.Cancel;
                    transactionToDB.UniqueTradeId = transaction.Element("id")?.Value;
                    transactionToDB.ExecutingPartyLEI = transaction.Element("Executing")?.Value;
                    transactionToDB.SubmittingPartyLEI = transaction.Element("Submitting")?.Value;
                }
                DBFake.FakeDB.AddToDB(transactionToDB);
            }
            
        }
    }
}
