 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using transj.Data;

namespace transj.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        DataContex api;

        public ClienteController(DataContex context)
        {
            api = context;
        }

        //private static List<cliente> clientes = new List<cliente>
            //{
            //    new cliente { cedula_cliente= "4938696",
            //        tipo_doc= "USD",
            //        nombre_apellido="Daniel Silva"
            //    },
            //      new cliente { cedula_cliente= "16345465",
            //        tipo_doc= "CI",
            //        nombre_apellido="Ruben Silva"
            //    }

            //};






        [HttpGet]

        public async Task<ActionResult<List<cliente>>> Get()
        {
            return Ok(await api.clientes.ToListAsync());
        }



        [HttpGet("{id}")]

        public async Task<ActionResult<cliente>> Get(string id)
        {
            var Clientes =  await api. clientes.FindAsync(id);
            if (Clientes == null)
                return BadRequest("NOSE A ENCONTRADO EL CLIETNE");

            return Ok(Clientes);
        }
        [HttpPost]

        //public IActionResult Post([FromBody] cliente clientes)
        //{
        //    context.SA();

        //     return Ok();
        //}

        public async Task<ActionResult<List<cliente>>> Addcliente(cliente cliente)
        {
            api.clientes.Add(cliente);
            await api.SaveChangesAsync();
            return Ok(await api.clientes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<cliente>>> Updatecliente(cliente request)
        {
            var modicliente =  api.clientes.Find(request.cedula_cliente);
            if (modicliente == null)
                return BadRequest("NOSE A ENCONTRADO EL CLIETNE");


            modicliente.cedula_cliente = request.cedula_cliente;

            modicliente.tipo_doc = request.tipo_doc;
            modicliente.nombre_apellido = request.nombre_apellido;


            await api.SaveChangesAsync();

            //return Ok(clientes);
            return Ok(await api.clientes.ToListAsync());
        }


        [HttpDelete("{cedula_cliente}")]

        public async Task<ActionResult<List<cliente>>> Delete(string cedula_cliente)
        {
            var elimininar = api.clientes.Find(cedula_cliente);
            if (elimininar == null)
                return BadRequest("NOSE A ENCONTRADO EL CLIETNE");

            api.clientes.Remove(elimininar);

            await api.SaveChangesAsync();
            //return Ok(clientes);

            //return Ok(await api.clientes.ToListAsync());

            return Ok();
        }


        [HttpGet]
        [Route("createDB")]
        public IActionResult CreaDatabase()
        {
            api.Database.EnsureCreated();

            return Ok();
        }
    }
    }

