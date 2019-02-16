using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderOfServiceDetail = new HashSet<OrderOfServiceDetail>();
        }

        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceCharge { get; set; }
        public bool ServiceIsDelete { get; set; }

        public virtual ICollection<OrderOfServiceDetail> OrderOfServiceDetail { get; set; }
    }
}
