using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Problem
    {
        public Problem()
        {
            ProblemOfCustomer = new HashSet<ProblemOfCustomer>();
        }

        public Guid ProblemId { get; set; }
        public string ProblemTitle { get; set; }
        public string ProblemContent { get; set; }
        public bool ProblemIsDelete { get; set; }

        public virtual ICollection<ProblemOfCustomer> ProblemOfCustomer { get; set; }
    }
}
