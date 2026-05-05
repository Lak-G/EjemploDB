using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EjemploDB.Data;
using EjemploDB.Models;

namespace EjemploDB.Pages.Productos;

// recibe el contexto de base de datos por inyeccion de dependencias
public class DeleteModel(AppDbContext db) : PageModel
{
    public Producto Producto { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        // busca el producto para mostrar sus datos antes de eliminar
        var producto = await db.Productos.FindAsync(id);
        if (producto is null) return NotFound();
        Producto = producto;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var producto = await db.Productos.FindAsync(id);

        if (producto is not null)
        {
            // elimina el producto y confirma el cambio en la base de datos
            db.Productos.Remove(producto);
            await db.SaveChangesAsync();
        }
        return RedirectToPage("Index");
    }
}
