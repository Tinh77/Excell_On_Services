using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class OrderOfService
    {
        public OrderOfService()
        {
            OrderOfServiceDetail = new HashSet<OrderOfServiceDetail>();
        }

        public Guid OrderOfServiceId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public string OrderOfServiceDescription { get; set; }
        public string OrderOfServicePaymentMethod { get; set; }
        public DateTime OrderOfServicePaymentDate { get; set; }
        public DateTime OrderOfServiceBillDate { get; set; }
        public int OrderOfServiceStatus { get; set; }
        public bool OrderOfServiceIsDelete { get; set; }

        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderOfServiceDetail> OrderOfServiceDetail { get; set; }
    }
}
