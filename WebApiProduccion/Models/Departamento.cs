using System.ComponentModel.DataAnnotations;

namespace WebApiProduccion.Models
{
    public class Departamento
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
