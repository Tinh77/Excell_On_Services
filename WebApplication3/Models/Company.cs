using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Company
    {
        public Company()
        {
            CustomerOfCompany = new HashSet<CustomerOfCompany>();
            Dealer = new HashSet<Dealer>();
            OrderOfService = new HashSet<OrderOfService>();
            ProblemOfCustomer = new HashSet<ProblemOfCustomer>();
            Product = new HashSet<Product>();
        }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }
        public bool CompanyIsDelete { get; set; }

        public virtual ICollection<CustomerOfCompany> CustomerOfCompany { get; set; }
        public virtual ICollection<Dealer> Dealer { get; set; }
        public virtual ICollection<OrderOfService> OrderOfService { get; set; }
        public virtual ICollection<ProblemOfCustomer> ProblemOfCustomer { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
