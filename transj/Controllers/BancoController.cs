using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using transj.Data;

namespace transj.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class BancoController : ControllerBase
    {

        DataContex api;


        public BancoController(DataContex context)
        {
            api = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<banco>>> Get()
        {
            return Ok(await api.bancoes.ToListAsync());
        }



        [HttpGet("{cod_banco}")]

        public async Task<ActionResult<banco>> Get(string cod_banco)
        {
            var bancos = await api.bancoes.FindAsync(cod_banco);
            if (bancos == null)
                return BadRequest("NOSE A ENCONTRADO EL BANCO");

            return Ok(bancos);
        }

        [HttpPost]
        public async Task<ActionResult<List<banco>>> Addbanco(banco bancos)
        {
            var add = api.bancoes.Find(bancos.cod_banco);

            if (add != null)
            {
                return BadRequest("EXISTE UN BANCO CON ESTE CODIGO DE BANCO");
            }
            api.bancoes.Add(bancos);
            await api.SaveChangesAsync();
            return Ok(await api.bancoes.ToListAsync());
        }


        [HttpPut]

        public async Task<ActionResult<List<banco>>> Updatebanco(banco request)
        {
            var modobanco = api.bancoes.Find(request.cod_banco);
            if (modobanco == null)
                return BadRequest("NOSE A ENCONTRADO EL BANCO");


            modobanco.cod_banco = request.cod_banco;

            modobanco.nombre_banco = request.nombre_banco;
            modobanco.direccion = request.direccion;


            await api.SaveChangesAsync();

            //return Ok(clientes);
            return Ok(await api.bancoes.ToListAsync());
        }
        [HttpDelete("{cod_banco}")]

        public async Task<ActionResult<List<banco>>> Delete(string cod_banco)
        {
            var elimininar = api.bancoes.Find(cod_banco);
            if (elimininar == null)
                return BadRequest("NOSE A ENCONTRADO EL BANCO");

            api.bancoes.Remove(elimininar);

            await api.SaveChangesAsync();
            //return Ok(clientes);

            //return Ok(await api.clientes.ToListAsync());

            return Ok("EL BANCO INGRESADO SE A ELIMINADO");
        }
    }
}
