using System;

namespace TestProjectXMLGit
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].EndsWith(".xml"))
            {
                // try to open the file
            }
            else
            {
                Console.WriteLine("Invalid use! Try: TestProjektXMLGit yourxml.xml");
            }
        }
    }
}