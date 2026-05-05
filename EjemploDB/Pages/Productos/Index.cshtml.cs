using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EjemploDB.Data;
using EjemploDB.Models;

namespace EjemploDB.Pages.Productos;

// recibe el contexto de base de datos por inyeccion de dependencias
public class IndexModel(AppDbContext db) : PageModel
{
    public List<Producto> Productos { get; set; } = [];

    public async Task OnGetAsync()
    {
        // trae todos los productos almacenados
        Productos = await db.Productos.ToListAsync();
    }
}
