using TP1.Models;

namespace TP1.Service
{
    public class ClientesDataStore
    {

        public List<Cliente> BDClientes { get; set; }

        public static ClientesDataStore Current { get; } = new ClientesDataStore();

        public ClientesDataStore()
        {

            BDClientes = new List<Cliente>()
            {
                new Cliente()
                {
                    //id = ClientesDataStore.Current.BDClientes.Max(c=>c.id)+1,
                    id =1,
                    nombre= "Leonardo",
                    apellido="Caceres",
                    email= "@",
                    telefono ="123456"
                },
                new Cliente()
                {
                    //id = ClientesDataStore.Current.BDClientes.Max(c=>c.id)+1,
                    id = 2,
                    nombre= "Leonardo2",
                    apellido="Caceres2",
                    email= "@2",
                    telefono ="123456"
                },
                new Cliente()
                {
                    //id = ClientesDataStore.Current.BDClientes.Max(c=>c.id)+1,
                    id=3,
                    nombre= "Leonardo3",
                    apellido="Caceres3",
                    email= "@3",
                    telefono ="123456"
                },
            };

        }

        public void InsertarDataStore(Cliente p)
        {
            BDClientes.Add(p);
        }
    }
}
