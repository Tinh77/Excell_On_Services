using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryIsDelete { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
