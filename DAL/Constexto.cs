using Microsoft.EntityFrameworkCore;
using Tarea3LabRegistros.Entidades;

public class Contexto:DbContext
{
    
    public DbSet<Carreras>? Carreras { get; set; } 
    public DbSet<Estudiantes>? Estudiantes { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Carreras.db");

        optionsBuilder.UseSqlite("Data Source = Estudiantes.db");
    }

}