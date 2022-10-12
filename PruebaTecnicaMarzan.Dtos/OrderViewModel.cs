using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnicaMarzan.ViewModels
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string Customer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
