using System.ComponentModel.DataAnnotations;

namespace Tarea3LabRegistros.Entidades
{
    public class Carreras
    {
        [Key]
        public int CarreraId { get; set; }
        public string Nombre { get; set; }
      
    }
}