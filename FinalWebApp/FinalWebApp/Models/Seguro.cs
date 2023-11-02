using System.ComponentModel.DataAnnotations;

namespace The_Last_Dance_First_Try.Models

{
    public class Seguro
    {
        [Key]
        public int IdSeguro { get; set; }
        public string Tipo { get; set; }
        public float Importe { get; set;}
        public string FechaImporte { get; set;}
    }
}
