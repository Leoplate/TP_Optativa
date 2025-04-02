namespace TP1.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public double Precio { get; set; }
    }

    public class ProduBase
    {

        public required string Descripcion { get; set; } = string.Empty;
        public double Precio { get; set; }
    }
}
