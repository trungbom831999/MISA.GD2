using System;
using System.Collections.Generic;

#nullable disable

namespace test2.Models
{
    public partial class Supplier
    {
        public string Typeofsupplier { get; set; }
        public bool? Iscustomer { get; set; }
        public string Suppliername { get; set; }
        public string Suppliervocative { get; set; }
        public string Supplierphone { get; set; }
        public string Supplierwebsite { get; set; }
        public string Supplieraddress { get; set; }
        public string Listsuppliergroup { get; set; }
        public string Purchasingstaffcode { get; set; }
        public string Personcontactvocative { get; set; }
        public string Personcontactname { get; set; }
        public string Personcontactemail { get; set; }
        public string Personcontactphone { get; set; }
        public string Receiverebillname { get; set; }
        public string Receiverebillemail { get; set; }
        public string Receiverebillphone { get; set; }
        public string Legalrepresentation { get; set; }
        public string Infocontactemail { get; set; }
        public string Infocontactphone { get; set; }
        public string Infocontactlandlinephone { get; set; }
        public string Identitycardnumber { get; set; }
        public DateTime? Identitycarddateprovied { get; set; }
        public string Identitycardaddress { get; set; }
        public string Termofpayment { get; set; }
        public double? Numberofdaysowned { get; set; }
        public double? Maxdebt { get; set; }
        public string Accountdebtcash { get; set; }
        public string Accountdebtpay { get; set; }
        public string Listaccountbank { get; set; }
        public string Otheraddressnation { get; set; }
        public string Otheraddressprovince { get; set; }
        public string Otheraddressdistrict { get; set; }
        public string Otheraddresssubdistrict { get; set; }
        public string Listplacedelivery { get; set; }
        public string Suppliernote { get; set; }
        public string Suppliercode { get; set; }
        public string Suppliertaxcode { get; set; }
        public Guid Idsupplier { get; set; }
    }
}
