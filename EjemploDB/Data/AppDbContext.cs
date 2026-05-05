using Microsoft.EntityFrameworkCore;
using EjemploDB.Models;

namespace EjemploDB.Data;

// contexto principal que representa la conexion con la base de datos
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // tabla de productos en la base de datos
    public DbSet<Producto> Productos { get; set; }
}
