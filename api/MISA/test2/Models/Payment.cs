using System;
using System.Collections.Generic;

#nullable disable

namespace test2.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Accoutings = new HashSet<Accouting>();
        }

        public string Paymentobjectcode { get; set; }
        public string Paymentobjectname { get; set; }
        public string Paymentaddress { get; set; }
        public string Reasonpay { get; set; }
        public string Paymentemployeecode { get; set; }
        public decimal? Numberoflicense { get; set; }
        public DateTime? Accountingdate { get; set; }
        public DateTime? Paymentdate { get; set; }
        public string Typeofmoney { get; set; }
        //public string Accountinglist { get; set; }
        public double? Totalmoney { get; set; }
        public string Paymentnumber { get; set; }
        public Guid Idpayment { get; set; }
        public virtual ICollection<Accouting> Accoutings { get; set; }
    }
}
