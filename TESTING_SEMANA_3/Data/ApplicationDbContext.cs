using Microsoft.EntityFrameworkCore;
using ProyectoFichaMedica.Models;

namespace ProyectoFichaMedica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Esta línea le dice a EF Core que en nuestra base de datos existe una tabla
        // que corresponde a nuestro modelo "FichaMedica".
        // La llamamos "FichasMedicas" para poder hacer consultas como: _context.FichasMedicas.ToList()
        public DbSet<FichaMedica> FichasMedicas { get; set; }
    }
}