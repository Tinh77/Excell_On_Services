using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class News
    {
        public Guid NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime NewsDate { get; set; }
        public bool NewsIsDelete { get; set; }
    }
}
