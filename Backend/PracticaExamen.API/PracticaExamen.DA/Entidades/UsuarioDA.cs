using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Entidades
{
    [Table("Usuario")]
    public class UsuarioDA
    {
        [Required]
        [StringLength(12)]
        [RegularExpression(@"\d{2}-\d{4}-\d{4}")]
        [Key]
        public string CardUser { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [RegularExpression(@"\d{4}-\d{4}")]
        public string PhoneNumber { get; set; }
        public DateTime UserBirthdate { get; set; }
        [Required]
        [StringLength(25)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string Password { get; set; }
    }
}
