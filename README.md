# EjemploDB

Aplicación web de ejemplo para enseñar los conceptos básicos de acceso a datos con **ASP.NET Core Razor Pages** y **Entity Framework Core**. Implementa un CRUD completo sobre una tabla de productos usando una base de datos SQLite local.

## Tecnologías

- [.NET 10](https://dotnet.microsoft.com/) — ASP.NET Core Razor Pages
- [Entity Framework Core 10](https://learn.microsoft.com/ef/core/) — ORM para acceso a datos
- [SQLite](https://www.sqlite.org/) — Base de datos embebida (archivo `tienda.db`)

## Estructura del proyecto

```
EjemploDB/
├── Data/
│   └── AppDbContext.cs       # Contexto de EF Core
├── Models/
│   └── Producto.cs           # Modelo de datos
├── Pages/
│   └── Productos/
│       ├── Index.cshtml      # Listado de productos
│       ├── Create.cshtml     # Formulario de creación
│       ├── Edit.cshtml       # Formulario de edición
│       └── Delete.cshtml     # Confirmación de eliminación
├── Program.cs                # Configuración de la aplicación
└── tienda.db                 # Base de datos SQLite (se genera automáticamente)
```

## Modelo de datos

La aplicación maneja una única entidad `Producto`:

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public float Precio { get; set; }
    public int Cantidad { get; set; }
}
```

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Cómo ejecutar

```bash
# Clona el repositorio
git clone <url-del-repositorio>
cd EjemploDB

# Ejecuta la aplicación
dotnet run --project EjemploDB
```

La base de datos `tienda.db` se crea automáticamente al iniciar la aplicación si no existe. Abre el navegador en `https://localhost:5001` (o el puerto que indique la consola).

## Conceptos que se trabajan

- Registro de `DbContext` en el contenedor de dependencias
- Uso de `EnsureCreated()` para inicializar la base de datos sin migraciones
- Patrón Repository implícito con `DbSet<T>`
- CRUD con Razor Pages (Page Model + vista)
- Enlace de rutas con `asp-route-id`
