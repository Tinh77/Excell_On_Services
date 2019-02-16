using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ProblemOfCustomer
    {
        public Guid ProblemOfCustomerId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ProblemId { get; set; }
        public DateTime ProblemOfCustomerDate { get; set; }
        public bool ProblemOfCustomerIsDelete { get; set; }

        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
