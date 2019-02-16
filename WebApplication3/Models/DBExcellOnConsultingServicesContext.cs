using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class DBExcellOnConsultingServicesContext : DbContext
    {
        public DBExcellOnConsultingServicesContext()
        {
        }

        public DBExcellOnConsultingServicesContext(DbContextOptions<DBExcellOnConsultingServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOfCompany> CustomerOfCompany { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrderOfService> OrderOfService { get; set; }
        public virtual DbSet<OrderOfServiceDetail> OrderOfServiceDetail { get; set; }
        public virtual DbSet<Problem> Problem { get; set; }
        public virtual DbSet<ProblemOfCustomer> ProblemOfCustomer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6PVISEO;User Id=sa;Password=12345678;Database=DBExcellOnConsultingServices;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.AccountUserName)
                    .HasName("UQ__Account__82AAF386E3C03306")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("UQ__Account__781134A0F322F6C8")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasColumnName("Account_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountIsDelete).HasColumnName("Account_IsDelete");

                entity.Property(e => e.AccountIsLocked).HasColumnName("Account_IsLocked");

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasColumnName("Account_Password")
                    .HasMaxLength(128);

                entity.Property(e => e.AccountUserName)
                    .IsRequired()
                    .HasColumnName("Account_UserName")
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("Role_Name")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Employee");

                entity.HasOne(d => d.RoleNameNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Category__B35EB419AB87C71D")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryIsDelete).HasColumnName("Category_IsDelete");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.CompanyEmail)
                    .HasName("UQ__Company__E045FD3B9FF31DE5")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyName)
                    .HasName("UQ__Company__F32A5ED9EA31A62C")
                    .IsUnique();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("Company_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("Company_Address")
                    .HasMaxLength(256);

                entity.Property(e => e.CompanyDescription).HasColumnName("Company_Description");

                entity.Property(e => e.CompanyEmail)
                    .HasColumnName("Company_Email")
                    .HasMaxLength(256);

                entity.Property(e => e.CompanyIsDelete).HasColumnName("Company_IsDelete");

                entity.Property(e => e.CompanyLogo).HasColumnName("Company_Logo");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(256);

                entity.Property(e => e.CompanyPhone)
                    .HasColumnName("Company_Phone")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.ContactEmail)
                    .HasName("UQ__Contact__6D966B2C409562B0")
                    .IsUnique();

                entity.Property(e => e.ContactId)
                    .HasColumnName("Contact_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContactContent).HasColumnName("Contact_Content");

                entity.Property(e => e.ContactDate)
                    .HasColumnName("Contact_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasColumnName("Contact_Email")
                    .HasMaxLength(256);

                entity.Property(e => e.ContactIsDelete).HasColumnName("Contact_IsDelete");

                entity.Property(e => e.ContactName)
                    .HasColumnName("Contact_Name")
                    .HasMaxLength(256);

                entity.Property(e => e.ContactStatus).HasColumnName("Contact_Status");

                entity.Property(e => e.ContactTitle)
                    .IsRequired()
                    .HasColumnName("Contact_Title")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerAddress)
                    .HasColumnName("Customer_Address")
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerFulName)
                    .IsRequired()
                    .HasColumnName("Customer_FulName")
                    .HasMaxLength(256);

                entity.Property(e => e.CustomerIsDelete).HasColumnName("Customer_IsDelete");

                entity.Property(e => e.CustomerPhone)
                    .HasColumnName("Customer_Phone")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<CustomerOfCompany>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CompanyId });

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CustomerOfCompanyIsDelete).HasColumnName("CustomerOfCompany_IsDelete");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CustomerOfCompany)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerOfCompany_Company");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOfCompany)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerOfCompany_Customer");
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.Property(e => e.DealerId)
                    .HasColumnName("Dealer_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.DealerAddress)
                    .HasColumnName("Dealer_Address")
                    .HasMaxLength(256);

                entity.Property(e => e.DealerEmail)
                    .HasColumnName("Dealer_Email")
                    .HasMaxLength(256);

                entity.Property(e => e.DealerIsDelete).HasColumnName("Dealer_IsDelete");

                entity.Property(e => e.DealerName)
                    .IsRequired()
                    .HasColumnName("Dealer_Name")
                    .HasMaxLength(256);

                entity.Property(e => e.DealerPhone)
                    .HasColumnName("Dealer_Phone")
                    .HasMaxLength(16);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Dealer)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dealer_Company");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentName)
                    .HasName("UQ__Departme__05A1CF34F1A952FD")
                    .IsUnique();

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DepartmentDescription).HasColumnName("Department_Description");

                entity.Property(e => e.DepartmentIsDelete).HasColumnName("Department_IsDelete");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("Department_Name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.EmployeeAddress)
                    .HasColumnName("Employee_Address")
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeAvatar).HasColumnName("Employee_Avatar");

                entity.Property(e => e.EmployeeDateOfBirth)
                    .HasColumnName("Employee_DateOfBirth")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasColumnName("Employee_Email")
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeFirtName)
                    .HasColumnName("Employee_FirtName")
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeeGender).HasColumnName("Employee_Gender");

                entity.Property(e => e.EmployeeIsDelete).HasColumnName("Employee_IsDelete");

                entity.Property(e => e.EmployeeLastName)
                    .HasColumnName("Employee_LastName")
                    .HasMaxLength(256);

                entity.Property(e => e.EmployeePhoneNumber)
                    .HasColumnName("Employee_PhoneNumber")
                    .HasMaxLength(16);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId)
                    .HasColumnName("News_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.NewsContent).HasColumnName("News_Content");

                entity.Property(e => e.NewsDate)
                    .HasColumnName("News_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.NewsIsDelete).HasColumnName("News_IsDelete");

                entity.Property(e => e.NewsTitle)
                    .IsRequired()
                    .HasColumnName("News_Title")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<OrderOfService>(entity =>
            {
                entity.Property(e => e.OrderOfServiceId)
                    .HasColumnName("OrderOfService_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.OrderOfServiceBillDate)
                    .HasColumnName("OrderOfService_BillDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.OrderOfServiceDescription).HasColumnName("OrderOfService_Description");

                entity.Property(e => e.OrderOfServiceIsDelete).HasColumnName("OrderOfService_IsDelete");

                entity.Property(e => e.OrderOfServicePaymentDate)
                    .HasColumnName("OrderOfService_PaymentDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.OrderOfServicePaymentMethod)
                    .IsRequired()
                    .HasColumnName("OrderOfService_PaymentMethod")
                    .HasMaxLength(256);

                entity.Property(e => e.OrderOfServiceStatus).HasColumnName("OrderOfService_Status");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.OrderOfService)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderOfService_Company");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OrderOfService)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderOfService_Employee");
            });

            modelBuilder.Entity<OrderOfServiceDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderOfServiceId, e.ServiceId })
                    .HasName("PK_OrderServiceDetail");

                entity.Property(e => e.OrderOfServiceId).HasColumnName("OrderOfService_Id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.OrderOfServiceDetailFromDate)
                    .HasColumnName("OrderOfServiceDetail_FromDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.OrderOfServiceDetailIsDelete).HasColumnName("OrderOfServiceDetail_IsDelete");

                entity.Property(e => e.OrderOfServiceDetailNumberOfEmployee).HasColumnName("OrderOfServiceDetail_NumberOfEmployee");

                entity.Property(e => e.OrderOfServiceDetailToDate)
                    .HasColumnName("OrderOfServiceDetail_ToDate")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.OrderOfService)
                    .WithMany(p => p.OrderOfServiceDetail)
                    .HasForeignKey(d => d.OrderOfServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderOfServiceDetail_OrderOfService");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderOfServiceDetail)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderOfServiceDetail_Service");
            });

            modelBuilder.Entity<Problem>(entity =>
            {
                entity.Property(e => e.ProblemId)
                    .HasColumnName("Problem_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ProblemContent).HasColumnName("Problem_Content");

                entity.Property(e => e.ProblemIsDelete).HasColumnName("Problem_IsDelete");

                entity.Property(e => e.ProblemTitle)
                    .IsRequired()
                    .HasColumnName("Problem_Title")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ProblemOfCustomer>(entity =>
            {
                entity.Property(e => e.ProblemOfCustomerId)
                    .HasColumnName("ProblemOfCustomer_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.ProblemId).HasColumnName("Problem_Id");

                entity.Property(e => e.ProblemOfCustomerDate)
                    .HasColumnName("ProblemOfCustomer_Date")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ProblemOfCustomerIsDelete).HasColumnName("ProblemOfCustomer_IsDelete");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ProblemOfCustomer)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProblemOfCustomer_Company");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProblemOfCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProblemOfCustomer_Customer");

                entity.HasOne(d => d.Problem)
                    .WithMany(p => p.ProblemOfCustomer)
                    .HasForeignKey(d => d.ProblemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProblemOfCustomer_Problem");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.ProductDescription).HasColumnName("Product_Description");

                entity.Property(e => e.ProductExpiryDate)
                    .HasColumnName("Product_ExpiryDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ProductImage).HasColumnName("Product_Image");

                entity.Property(e => e.ProductIsDelete).HasColumnName("Product_IsDelete");

                entity.Property(e => e.ProductManufactureDate)
                    .HasColumnName("Product_ManufactureDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(256);

                entity.Property(e => e.ProductPrice)
                    .IsRequired()
                    .HasColumnName("Product_Price")
                    .HasMaxLength(256);

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasColumnName("Product_Type")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Company");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleName);

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(256)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleIsDelete).HasColumnName("Role_IsDelete");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.ServiceName)
                    .HasName("UQ__Service__D4BB225CC6292953")
                    .IsUnique();

                entity.Property(e => e.ServiceId)
                    .HasColumnName("Service_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ServiceCharge)
                    .IsRequired()
                    .HasColumnName("Service_Charge")
                    .HasMaxLength(256);

                entity.Property(e => e.ServiceDescription).HasColumnName("Service_Description");

                entity.Property(e => e.ServiceImage).HasColumnName("Service_Image");

                entity.Property(e => e.ServiceIsDelete).HasColumnName("Service_IsDelete");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("Service_Name")
                    .HasMaxLength(256);
            });
        }
    }
}
