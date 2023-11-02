using System.ComponentModel.DataAnnotations;

namespace The_Last_Dance_First_Try.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Genero { get; set; }
        public string FechaNacimiento { get; set; }

        public int IdDepartamento { get; set;}


    }
}
