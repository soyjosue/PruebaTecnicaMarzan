using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnicaMarzan.Models
{
    public class OrderCreateViewModel
    {
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
