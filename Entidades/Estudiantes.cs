using System.ComponentModel.DataAnnotations;

namespace Tarea3LabRegistros.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public int CarreraId { get; set; }
        public string Activo { get; set; }
      
    }
}