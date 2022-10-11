using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaMarzan.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime CreatedAt { get; set; }
    }
}
