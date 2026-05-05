namespace EjemploDB.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public float Precio { get; set; }
    public int Cantidad { get; set; }
}
