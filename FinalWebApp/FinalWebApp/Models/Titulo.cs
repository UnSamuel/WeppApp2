using System.ComponentModel.DataAnnotations;

namespace The_Last_Dance_First_Try.Models
{
    public class Titulo
    {
        [Key]
        public int IdTitulo { get; set; }
        public string titulo { get; set; }
        public string Descripcion { get; set;}

        public int IdEmpleado { get; set; }
    }
}
