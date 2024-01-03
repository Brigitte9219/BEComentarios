using BEComentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace BEComentarios
{
    public class AplicationDbContext : DbContext //Representa una sesión de la BD (almacenar datos, hacer querys...)
    {
        public DbSet<Comentario> Comentario { get; set; } //Estamos mapeando el modelo con la tabla de la BD

        public AplicationDbContext(DbContextOptions<AplicationDbContext>options): base(options) //constructor
        {
        
        }
    }
}
