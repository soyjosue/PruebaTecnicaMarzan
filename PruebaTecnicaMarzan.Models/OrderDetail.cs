using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaMarzan.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "El producto es obligatorio.")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "La orden es obligatoria.")]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public float Amount { get; set; }
        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime CreatedAt { get; set; }
    }
}
