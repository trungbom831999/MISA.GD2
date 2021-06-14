using System;
using System.Collections.Generic;

#nullable disable

namespace test2.Models
{
    public partial class Accouting
    {
        public string Description { get; set; }
        public string Accountdebtnumber { get; set; }
        public string Accountreceivenumber { get; set; }
        public double? Money { get; set; }
        public string Objectcode { get; set; }
        public string Objectname { get; set; }
        public Guid Idaccounting { get; set; }
        public Guid? Idpayment { get; set; }

        //public virtual Payment IdpaymentNavigation { get; set; }
    }
}
