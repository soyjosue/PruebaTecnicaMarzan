using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaMarzan.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime CreatedAt { get; set; }
    }
}
