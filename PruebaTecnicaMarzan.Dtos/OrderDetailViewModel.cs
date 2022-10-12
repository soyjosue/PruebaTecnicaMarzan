using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaMarzan.ViewModels
{
    public class OrderDetailViewModel
    {
        public int ID { get; set; }
        public string Product { get; set; }
        public string Order { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
    }
}
