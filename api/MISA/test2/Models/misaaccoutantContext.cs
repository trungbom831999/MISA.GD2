using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace test2.Models
{
    public partial class misaaccoutantContext : DbContext
    {
        public misaaccoutantContext()
        {
        }

        public misaaccoutantContext(DbContextOptions<misaaccoutantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accouting> Accoutings { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=misa.accoutant");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_Vietnam.1258");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Idaccount)
                    .HasName("account_pk");

                entity.ToTable("account", "accouting");

                entity.HasComment("Thông tin tài khoản");

                entity.HasIndex(e => e.Accountnumber, "account_un")
                    .IsUnique();

                entity.Property(e => e.Idaccount)
                    .ValueGeneratedNever()
                    .HasColumnName("idaccount");

                entity.Property(e => e.Accountconstruction)
                    .HasColumnType("character varying")
                    .HasColumnName("accountconstruction")
                    .HasComment("công trình");

                entity.Property(e => e.Accountitemcp)
                    .HasColumnType("character varying")
                    .HasColumnName("accountitemcp");

                entity.Property(e => e.Accountname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("accountname");

                entity.Property(e => e.Accountnameinenglish)
                    .HasColumnType("character varying")
                    .HasColumnName("accountnameinenglish");

                entity.Property(e => e.Accountnumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("accountnumber")
                    .HasComment("Số tài khoản");

                entity.Property(e => e.Accountobjectdefault)
                    .HasColumnType("character varying")
                    .HasColumnName("accountobjectdefault");

                entity.Property(e => e.Accountobjectthcp)
                    .HasColumnType("character varying")
                    .HasColumnName("accountobjectthcp");

                entity.Property(e => e.Accountorder)
                    .HasColumnType("character varying")
                    .HasColumnName("accountorder")
                    .HasComment("đơn đặt hàng");

                entity.Property(e => e.Accountpurchasecontract)
                    .HasColumnType("character varying")
                    .HasColumnName("accountpurchasecontract")
                    .HasComment("hợp đồng mua");

                entity.Property(e => e.Accountsalecontract)
                    .HasColumnType("character varying")
                    .HasColumnName("accountsalecontract")
                    .HasComment("hợp đồng bán");

                entity.Property(e => e.Accountstatisticalcode)
                    .HasColumnType("character varying")
                    .HasColumnName("accountstatisticalcode")
                    .HasComment("mã thống kê");

                entity.Property(e => e.Accountunit)
                    .HasColumnType("character varying")
                    .HasColumnName("accountunit");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Generalaccountnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("generalaccountnumber")
                    .HasComment("mã số tài khoản tổng hợp");

                entity.Property(e => e.Hasbankaccount).HasColumnName("hasbankaccount");

                entity.Property(e => e.Isaccountexception)
                    .HasColumnName("isaccountexception")
                    .HasComment("có hạch toán ngoại lệ hay không");

                entity.Property(e => e.Natureaccount)
                    .HasColumnType("character varying")
                    .HasColumnName("natureaccount")
                    .HasComment("tính chất tài khoản");
            });

            modelBuilder.Entity<Accouting>(entity =>
            {
                entity.HasKey(e => e.Idaccounting)
                    .HasName("accouting_pk");

                entity.ToTable("accouting", "accouting");

                entity.HasComment("Hạch toán");

                entity.Property(e => e.Idaccounting)
                    .ValueGeneratedNever()
                    .HasColumnName("idaccounting");

                entity.Property(e => e.Accountdebtnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("accountdebtnumber");

                entity.Property(e => e.Accountreceivenumber)
                    .HasColumnType("character varying")
                    .HasColumnName("accountreceivenumber");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Idpayment).HasColumnName("idpayment");

                entity.Property(e => e.Money).HasColumnName("money");

                entity.Property(e => e.Objectcode)
                    .HasColumnType("character varying")
                    .HasColumnName("objectcode");

                entity.Property(e => e.Objectname)
                    .HasColumnType("character varying")
                    .HasColumnName("objectname");

                //entity.HasOne(d => d.IdpaymentNavigation)
                //    .WithMany(p => p.Accoutings)
                //    .HasForeignKey(d => d.Idpayment)
                //    .HasConstraintName("accouting_fk");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Idpayment)
                    .HasName("payment_pk");

                entity.ToTable("payment", "accouting");

                entity.HasComment("Phiếu chi");

                entity.Property(e => e.Idpayment)
                    .ValueGeneratedNever()
                    .HasColumnName("idpayment");

                entity.Property(e => e.Accountingdate)
                    .HasColumnType("date")
                    .HasColumnName("accountingdate")
                    .HasComment("ngày hạch toán");

                entity.Property(e => e.Accountinglist)
                    .HasColumnType("json")
                    .HasColumnName("accountinglist")
                    .HasComment("danh sách tài khoản ngân hàng");

                entity.Property(e => e.Numberoflicense)
                    .HasColumnName("numberoflicense")
                    .HasComment("Số chứng từ gốc");

                entity.Property(e => e.Paymentaddress)
                    .HasColumnType("character varying")
                    .HasColumnName("paymentaddress");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("date")
                    .HasColumnName("paymentdate")
                    .HasComment("ngày phiếu chi");

                entity.Property(e => e.Paymentemployeecode)
                    .HasColumnType("character varying")
                    .HasColumnName("paymentemployeecode");

                entity.Property(e => e.Paymentnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("paymentnumber")
                    .HasComment("Số phiếu chi");

                entity.Property(e => e.Paymentobjectcode)
                    .HasColumnType("character varying")
                    .HasColumnName("paymentobjectcode");

                entity.Property(e => e.Paymentobjectname)
                    .HasColumnType("character varying")
                    .HasColumnName("paymentobjectname");

                entity.Property(e => e.Reasonpay)
                    .HasColumnType("character varying")
                    .HasColumnName("reasonpay")
                    .HasComment("Lý do chi");

                entity.Property(e => e.Totalmoney)
                    .HasColumnName("totalmoney")
                    .HasComment("tổng tiền");

                entity.Property(e => e.Typeofmoney)
                    .HasColumnType("character varying")
                    .HasColumnName("typeofmoney");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Idsupplier)
                    .HasName("supplier_pk");

                entity.ToTable("supplier", "accouting");

                entity.HasComment("Bảng nhà cung cấp (ncc)\r\nsupplier: nhà cung cấp\r\npersoncontact: người liên hệ\r\nreceiverEBill: người nhận hóa đơn điện tử\r\ninfoContact: thông tin liên hệ\r\nidentityCard: thẻ căn cước\r\notherAddress: địa chỉ khác");

                entity.HasIndex(e => e.Suppliercode, "supplier_un")
                    .IsUnique();

                entity.Property(e => e.Idsupplier)
                    .ValueGeneratedNever()
                    .HasColumnName("idsupplier");

                entity.Property(e => e.Accountdebtcash)
                    .HasColumnType("character varying")
                    .HasColumnName("accountdebtcash");

                entity.Property(e => e.Accountdebtpay)
                    .HasColumnType("character varying")
                    .HasColumnName("accountdebtpay");

                entity.Property(e => e.Identitycardaddress)
                    .HasColumnType("character varying")
                    .HasColumnName("identitycardaddress");

                entity.Property(e => e.Identitycarddateprovied)
                    .HasColumnType("date")
                    .HasColumnName("identitycarddateprovied");

                entity.Property(e => e.Identitycardnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("identitycardnumber");

                entity.Property(e => e.Infocontactemail)
                    .HasColumnType("character varying")
                    .HasColumnName("infocontactemail");

                entity.Property(e => e.Infocontactlandlinephone)
                    .HasColumnType("character varying")
                    .HasColumnName("infocontactlandlinephone");

                entity.Property(e => e.Infocontactphone)
                    .HasColumnType("character varying")
                    .HasColumnName("infocontactphone");

                entity.Property(e => e.Iscustomer)
                    .HasColumnName("iscustomer")
                    .HasComment("Có phải khách hàng hay không");

                entity.Property(e => e.Legalrepresentation)
                    .HasColumnType("character varying")
                    .HasColumnName("legalrepresentation");

                entity.Property(e => e.Listaccountbank)
                    .HasColumnType("json")
                    .HasColumnName("listaccountbank");

                entity.Property(e => e.Listplacedelivery)
                    .HasColumnType("json")
                    .HasColumnName("listplacedelivery");

                entity.Property(e => e.Listsuppliergroup)
                    .HasColumnType("json")
                    .HasColumnName("listsuppliergroup")
                    .HasComment("danh sách nhóm ncc");

                entity.Property(e => e.Maxdebt).HasColumnName("maxdebt");

                entity.Property(e => e.Numberofdaysowned).HasColumnName("numberofdaysowned");

                entity.Property(e => e.Otheraddressdistrict)
                    .HasColumnType("character varying")
                    .HasColumnName("otheraddressdistrict");

                entity.Property(e => e.Otheraddressnation)
                    .HasColumnType("character varying")
                    .HasColumnName("otheraddressnation");

                entity.Property(e => e.Otheraddressprovince)
                    .HasColumnType("character varying")
                    .HasColumnName("otheraddressprovince");

                entity.Property(e => e.Otheraddresssubdistrict)
                    .HasColumnType("character varying")
                    .HasColumnName("otheraddresssubdistrict");

                entity.Property(e => e.Personcontactemail)
                    .HasColumnType("character varying")
                    .HasColumnName("personcontactemail");

                entity.Property(e => e.Personcontactname)
                    .HasColumnType("character varying")
                    .HasColumnName("personcontactname");

                entity.Property(e => e.Personcontactphone)
                    .HasColumnType("character varying")
                    .HasColumnName("personcontactphone");

                entity.Property(e => e.Personcontactvocative)
                    .HasColumnType("character varying")
                    .HasColumnName("personcontactvocative");

                entity.Property(e => e.Purchasingstaffcode)
                    .HasColumnType("character varying")
                    .HasColumnName("purchasingstaffcode")
                    .HasComment("mã nhân viên mua hàng");

                entity.Property(e => e.Receiverebillemail)
                    .HasColumnType("character varying")
                    .HasColumnName("receiverebillemail");

                entity.Property(e => e.Receiverebillname)
                    .HasColumnType("character varying")
                    .HasColumnName("receiverebillname");

                entity.Property(e => e.Receiverebillphone)
                    .HasColumnType("character varying")
                    .HasColumnName("receiverebillphone");

                entity.Property(e => e.Supplieraddress)
                    .HasColumnType("character varying")
                    .HasColumnName("supplieraddress")
                    .HasComment("Địa chỉ ncc");

                entity.Property(e => e.Suppliercode)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("suppliercode")
                    .HasComment("Mã ncc");

                entity.Property(e => e.Suppliername)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("suppliername")
                    .HasComment("Tên ncc");

                entity.Property(e => e.Suppliernote)
                    .HasColumnType("character varying")
                    .HasColumnName("suppliernote");

                entity.Property(e => e.Supplierphone)
                    .HasMaxLength(20)
                    .HasColumnName("supplierphone")
                    .HasComment("Số điện thoại ncc");

                entity.Property(e => e.Suppliertaxcode)
                    .HasColumnType("character varying")
                    .HasColumnName("suppliertaxcode");

                entity.Property(e => e.Suppliervocative)
                    .HasMaxLength(255)
                    .HasColumnName("suppliervocative")
                    .HasComment("Xưng hô");

                entity.Property(e => e.Supplierwebsite)
                    .HasMaxLength(255)
                    .HasColumnName("supplierwebsite")
                    .HasComment("Website của ncc");

                entity.Property(e => e.Termofpayment)
                    .HasColumnType("character varying")
                    .HasColumnName("termofpayment");

                entity.Property(e => e.Typeofsupplier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("typeofsupplier")
                    .HasComment("Loại nhà cung cấp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
