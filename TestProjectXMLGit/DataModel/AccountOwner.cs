using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXMLGit.DataModel
{
    public class AccountOwner
    {
        public IdType Type { get; set; }
        public string Id { get; set; }
        public Person Person { get; set; }
    }
}
