using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EjemploDB.Data;
using EjemploDB.Models;

namespace EjemploDB.Pages.Productos;

// recibe el contexto de base de datos por inyeccion de dependencias
public class CreateModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public Producto Producto { get; set; } = new();

    public IActionResult OnGet() => Page();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // agrega el nuevo producto y guarda en la base de datos
        db.Productos.Add(Producto);
        await db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
