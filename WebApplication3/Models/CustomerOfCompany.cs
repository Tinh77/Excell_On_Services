using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class CustomerOfCompany
    {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public bool CustomerOfCompanyIsDelete { get; set; }

        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
