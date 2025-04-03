using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Data;
using TP1.Models;
using TP1.Service;


namespace TP1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        
        private readonly AppDbContext _appDbContext;
        public ClientesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _appDbContext.Clientes.ToListAsync();
            return Ok(clientes);
        }


        [HttpGet("{ClienteID}")]
        public async Task<ActionResult<Cliente>> GetClientes(int ClienteID)
        {

            //Console.WriteLine(ClienteID);

            //var resultado = ClientesDataStore.Current.BDClientes.FirstOrDefault(f => f.id == ClienteID);

            var resultado = await _appDbContext.Clientes.FirstOrDefaultAsync(c=>c.id == ClienteID);

            if (resultado == null)
            {
                return  NotFound("Te equivocastes de cliente");
            }

            return Ok(resultado);

        }

        [HttpPost]

        public async Task<ActionResult<Cliente>> PostCliente(ClienteBase clie)
        {

            //var maximo = ClientesDataStore.Current.BDClientes.Max(f => f.id);
            var maximo = await _appDbContext.Clientes.MaxAsync(f => f.id);

            var nuevoCli = new Cliente();

            nuevoCli.id = maximo + 1;
            nuevoCli.nombre = clie.nombre;
            nuevoCli.apellido = clie.apellido;
            nuevoCli.email = clie.email;
            nuevoCli.telefono = clie.telefono;

            await _appDbContext.Clientes.AddAsync(nuevoCli);
            await _appDbContext.SaveChangesAsync();
            //ClientesDataStore.Current.InsertarDataStore(nuevoCli);

            return Ok(nuevoCli);

            //return CreatedAtAction("GetProduct", nuevoProdu.id);

        }


        [HttpDelete("{ClienteID}")]

        public async Task<ActionResult<Cliente>> DeleteCliente(int ClienteID)
        {

            //var resultado = ClientesDataStore.Current.BDClientes.First(c => c.id == ClienteID);
            var resultado = await _appDbContext.Clientes.FirstAsync(c => c.id ==  ClienteID);

            if (resultado != null)
            {
                //ClientesDataStore.Current.BDClientes.Remove(resultado);
                 _appDbContext.Clientes.Remove(resultado);
                await _appDbContext.SaveChangesAsync();
                return Ok(resultado);
            }
            else
            {
                return NotFound("Te equivocastes de cliente");
            }

        }


        [HttpPut("{ClienteID}")]
        public async Task<ActionResult<Cliente>> PostCliente(int ClienteID, ClienteBase clie)
        {
            //var resultado = ClientesDataStore.Current.BDClientes.FirstOrDefault(c => c.id == ClienteID);

            var resultado = await _appDbContext.Clientes.FirstOrDefaultAsync(c => c.id == ClienteID);

            if (resultado != null)
            {
               resultado.nombre = clie.nombre;
               resultado.apellido = clie.apellido;
               resultado.email = clie.email;
               resultado.telefono = clie.telefono;
                _appDbContext.Clientes.Update(resultado);
                await _appDbContext.SaveChangesAsync();
               return Ok(resultado);
            }
            else
            {
                return NotFound("Te equivocastes de usuario");
            }
        }

    }
}
