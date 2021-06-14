using System;
using System.Collections.Generic;

#nullable disable

namespace test2.Models
{
    public partial class Account
    {
        public string Accountnumber { get; set; }
        public string Accountname { get; set; }
        public string Accountnameinenglish { get; set; }
        public string Generalaccountnumber { get; set; }
        public string Natureaccount { get; set; }
        public string Description { get; set; }
        public bool? Isaccountexception { get; set; }
        public string Accountobjectdefault { get; set; }
        public bool? Hasbankaccount { get; set; }
        public string Accountobjectthcp { get; set; }
        public string Accountconstruction { get; set; }
        public string Accountorder { get; set; }
        public string Accountsalecontract { get; set; }
        public string Accountpurchasecontract { get; set; }
        public string Accountitemcp { get; set; }
        public string Accountunit { get; set; }
        public string Accountstatisticalcode { get; set; }
        public Guid Idaccount { get; set; }
    }
}
