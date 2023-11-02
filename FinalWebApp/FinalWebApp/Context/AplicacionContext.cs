using Microsoft.EntityFrameworkCore;
using The_Last_Dance_First_Try.Models;

namespace The_Last_Dance_First_Try.Context
{
    public class AplicacionContext : DbContext
    {
        public AplicacionContext (DbContextOptions<AplicacionContext> options)
            : base(options)
        { 
        
        }

        public DbSet <Departamento> Departamento { get; set; }
        public DbSet <Empleado> Empleado { get; set; }
        public DbSet <Salario> Salario { get; set; }
        public DbSet <Seguro> Seguro { get; set; }
        public DbSet <Titulo> Titulo { get; set; }


    }
}
