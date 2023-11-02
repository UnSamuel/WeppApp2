using System.ComponentModel.DataAnnotations;

namespace The_Last_Dance_First_Try.Models
{
    public class Salario
    {
        [Key]
        public int IdSalario { get; set; }
        public float salario { get; set; }
        public string FechaInicio { get; set; }
    }
}
