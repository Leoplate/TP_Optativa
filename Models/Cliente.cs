namespace TP1.Models
{
    public class Cliente
    {

        public int id { get; set; }
        public String nombre { get; set; } = String.Empty;
        public String apellido { get; set;} = String.Empty;
        public String email { get; set;} = String.Empty;
        public String telefono { get; set;} = String.Empty;

        

        //public Cliente(String nombre,String apellido,String email, String telefono)
        //{
        //    this.id = Guid.NewGuid();
        //    this.nombre = nombre;
        //    this.apellido = apellido;
        //    this.email = email;
        //    this.telefono = telefono;
        //}
    }

    public class ClienteBase
    {

        public String nombre { get; set; } = String.Empty;
        public String apellido { get; set; } = String.Empty;
        public String email { get; set; } = String.Empty;
        public String telefono { get; set; } = String.Empty;


        //public Cliente(String nombre,String apellido,String email, String telefono)
        //{
        //    this.id = Guid.NewGuid();
        //    this.nombre = nombre;
        //    this.apellido = apellido;
        //    this.email = email;
        //    this.telefono = telefono;
        //}
    }

}
