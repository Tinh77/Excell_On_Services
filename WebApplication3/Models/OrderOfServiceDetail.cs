using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class OrderOfServiceDetail
    {
        public Guid OrderOfServiceId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime OrderOfServiceDetailFromDate { get; set; }
        public DateTime OrderOfServiceDetailToDate { get; set; }
        public int OrderOfServiceDetailNumberOfEmployee { get; set; }
        public bool OrderOfServiceDetailIsDelete { get; set; }

        public virtual OrderOfService OrderOfService { get; set; }
        public virtual Service Service { get; set; }
    }
}
