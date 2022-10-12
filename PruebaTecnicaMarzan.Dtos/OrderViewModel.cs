using PruebaTecnicaMarzan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaMarzan.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Identificador")]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [Display(Name = "Cliente")]
        public string Customer { get; set; }
        [Display(Name = "Ganancia")]
        public float Cantidad { get; set; }
        [Display(Name = "Fecha")]
        public DateTime CreatedAt { get; set; }

        public virtual List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
