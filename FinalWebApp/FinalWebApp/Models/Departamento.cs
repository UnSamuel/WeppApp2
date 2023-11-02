using System.ComponentModel.DataAnnotations;

namespace The_Last_Dance_First_Try.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
    }
}
