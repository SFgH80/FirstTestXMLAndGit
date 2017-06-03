using System;

namespace TestProjectXMLGit
{
    public class Program
    {
        static void Main(string[] args)
        {
            XMLParser hans = new XMLParser("TestReport.xml");
            foreach (var transaction in DBFake.FakeDB.GetTransactions())
                Console.WriteLine(transaction.ToString());
            Console.ReadLine();
        }
    }
}