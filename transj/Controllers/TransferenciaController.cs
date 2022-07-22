
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using transj.Data;
namespace transj.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController :ControllerBase
    {

        DataContex api;


        public TransferenciaController(DataContex context)
        {
            api = context;
        }



        [HttpGet]

        public async Task<ActionResult<List<transferencia>>> Get()
        {
            return Ok(await api.transferencias.ToListAsync());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<transferencia>> Get(Guid id)
        {
            var Tranferencia = await api.transferencias.FindAsync(id);
            if (Tranferencia == null)
                return BadRequest("NOSE A ENCONTRADO EL TRANSFERENCIA");

            return Ok(Tranferencia);
        }

        [HttpPost]
        public async Task<ActionResult<List<transferencia>>> Addcliente(transferencia transferencia)
        {
            api.transferencias.Add(transferencia);
            await api.SaveChangesAsync();
            return Ok(await api.transferencias.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<transferencia>>> Updatetransferencia(transferencia request)
        {
            var modicliente = api.transferencias.Find(request.id_transaccion);
            if (modicliente == null)
                return BadRequest("NOSE A ENCONTRADO EL TRANSACION");


            modicliente.num_cta = request.num_cta;

            modicliente.cedula_cliente = request.cedula_cliente;
            modicliente.fecha = request.fecha;
            modicliente.monto = request.monto;
            modicliente.estado = request.estado;



            await api.SaveChangesAsync();

            //return Ok(clientes);
            return Ok(await api.transferencias.ToListAsync());
        }
        [HttpDelete("{id_transaccion}")]

        public async Task<ActionResult<List<transferencia>>> Delete(Guid id_transaccion)
        {
            var elimininar = api.transferencias.Find(id_transaccion);
            if (elimininar == null)
                return BadRequest("NOSE A ENCONTRADO EL TRANSFERENCIA");

            api.transferencias.Remove(elimininar);

            await api.SaveChangesAsync();
            //return Ok(clientes);

            //return Ok(await api.clientes.ToListAsync());

            return Ok(); //hola
        }

    }
}
