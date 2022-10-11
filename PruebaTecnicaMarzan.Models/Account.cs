using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaMarzan.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contrase es obligatoria.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El rol es obligatorio.")]
        public int Role { get; set; }
        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime CreatedAt { get; set; }
    }
}
