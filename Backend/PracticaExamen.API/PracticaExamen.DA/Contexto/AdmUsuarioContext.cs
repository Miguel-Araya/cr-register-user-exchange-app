using Microsoft.EntityFrameworkCore;
using PracticaExamen.DA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.DA.Contexto
{
    public class AdmUsuarioContext:DbContext
    {
        public AdmUsuarioContext(DbContextOptions options): base(options) { 
        
            
        }
        public DbSet<UsuarioDA> Usuarios { get; set; }
        public DbSet<LogDA> Logs { get; set; }

    }
}
