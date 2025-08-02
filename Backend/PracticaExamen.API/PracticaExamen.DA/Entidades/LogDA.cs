using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Entidades
{
    [Table("Log")]
    public class LogDA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idLog { get; set; }
        [Required]
        [StringLength(50)]
        public string typeLog { get; set; }
        [Required]
        [StringLength(50)]
        public string tableLog { get; set; }
        [Required]
        [StringLength(200)]
        public string descriptionLog { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime dateLog { get; set; }
    }
}
