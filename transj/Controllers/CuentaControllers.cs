using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using transj.Data;
namespace transj.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CuentaControllers : ControllerBase
    {
        DataContex api;


        public CuentaControllers(DataContex context)
        {
            api = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<cuenta>>> Get()
        {
            return Ok(await api.cuentas.ToListAsync());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<cuenta>> Get(string id)
        {
            var Cuentasid = await api.cuentas.FindAsync(id);
            if (Cuentasid == null)
                return BadRequest("NOSE A ENCONTRADO LA CUENTA");

            return Ok(Cuentasid);
        }


        [HttpPost]

        public async Task<ActionResult<List<cuenta>>> Addcuenta(cuenta cuenta)
        {
            var add = api.cuentas.Find(cuenta.num_cta);
            if (add != null)
            {
                return BadRequest("EXISTE UN CUENTAN CON ESTE NUMERO DE CUENTA");
            }
            api.cuentas.Add(cuenta);
            await api.SaveChangesAsync();
            return Ok(await api.cuentas.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<cuenta>>> Updatecuenta(cuenta request)
        {
            var modicuenta = api.cuentas.Find(request.num_cta);
            if (modicuenta == null)
                return BadRequest("NOSE A ENCONTRADO EL CUENTA");


            

            modicuenta.num_cta = request.num_cta;
            modicuenta.moneda = request.moneda;
            modicuenta.moneda = request.moneda;
            modicuenta.cedula_cliente = request.cedula_cliente;
            modicuenta.saldo = request.saldo;
            modicuenta.cod_banco = request.cod_banco;
            modicuenta.Cliente = request.Cliente;
            modicuenta.Banco = request.Banco;


            await api.SaveChangesAsync();

            //return Ok(clientes);
            return Ok(await api.cuentas.ToListAsync());
        }

        [HttpDelete("{num_cta}")]

        public async Task<ActionResult<List<cuenta>>> Delete(string num_cta)
        {
            var eliminarcuenta = api.cuentas.Find(num_cta);
            if (eliminarcuenta == null)
                return BadRequest("NOSE A ENCONTRADO EL CUENTA");

            api.cuentas.Remove(eliminarcuenta);

            await api.SaveChangesAsync();
            //return Ok(clientes);

            //return Ok(await api.clientes.ToListAsync());

            return Ok();
        }
    }
}
