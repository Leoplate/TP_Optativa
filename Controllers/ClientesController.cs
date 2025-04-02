using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TP1.Models;
using TP1.Service;

namespace TP1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return ClientesDataStore.Current.BDClientes;
        }

        [HttpGet("{ClienteID}")]
        public ActionResult<Cliente> GetClientes(int ClienteID)
        {

            //Console.WriteLine(ClienteID);

            var resultado = ClientesDataStore.Current.BDClientes.FirstOrDefault(f => f.id == ClienteID);


            if (resultado == null)
            {
                return NotFound("Te equivocastes de cliente");
            }

            return Ok(resultado);

        }

        [HttpPost]

        public ActionResult<Cliente> PostCliente(ClienteBase clie)
        {

            var maximo = ClientesDataStore.Current.BDClientes.Max(f => f.id);

            var nuevoCli = new Cliente();

            nuevoCli.id = maximo + 1;
            nuevoCli.nombre = clie.nombre;
            nuevoCli.apellido = clie.apellido;
            nuevoCli.email = clie.email;
            nuevoCli.telefono = clie.telefono;

            ClientesDataStore.Current.InsertarDataStore(nuevoCli);

            return Ok(nuevoCli);

            //return CreatedAtAction("GetProduct", nuevoProdu.id);

        }


        [HttpDelete("{ClienteID}")]

        public ActionResult<Cliente> DeleteCliente(int ClienteID)
        {

            var resultado = ClientesDataStore.Current.BDClientes.First(c => c.id == ClienteID);

            if (resultado != null)
            {
                ClientesDataStore.Current.BDClientes.Remove(resultado);
                return Ok(resultado);
            }
            else
            {
                return NotFound("Te equivocastes de cliente");
            }

        }


        [HttpPut("{ClienteID}")]
        public ActionResult<Cliente> PostCliente(int ClienteID, ClienteBase clie)
        {
            var resultado = ClientesDataStore.Current.BDClientes.FirstOrDefault(c => c.id == ClienteID);

            if (resultado != null)
            {
               resultado.nombre = clie.nombre;
               resultado.apellido = clie.apellido;
               resultado.email = clie.email;
               resultado.telefono = clie.telefono;
               return Ok(resultado);
            }
            else
            {
                return NotFound("Te equivocastes de usuario");
            }
        }

    }
}
