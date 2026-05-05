using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EjemploDB.Data;
using EjemploDB.Models;

namespace EjemploDB.Pages.Productos;

// recibe el contexto de base de datos por inyeccion de dependencias
public class EditModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public Producto Producto { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        // busca el producto por su id en la base de datos
        var producto = await db.Productos.FindAsync(id);
        if (producto is null) return NotFound();
        Producto = producto;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // aplica los cambios y los guarda en la base de datos
        db.Productos.Update(Producto);
        await db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
