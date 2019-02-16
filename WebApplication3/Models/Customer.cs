using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOfCompany = new HashSet<CustomerOfCompany>();
            ProblemOfCustomer = new HashSet<ProblemOfCustomer>();
        }

        public Guid CustomerId { get; set; }
        public string CustomerFulName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public bool CustomerIsDelete { get; set; }

        public virtual ICollection<CustomerOfCompany> CustomerOfCompany { get; set; }
        public virtual ICollection<ProblemOfCustomer> ProblemOfCustomer { get; set; }
    }
}
