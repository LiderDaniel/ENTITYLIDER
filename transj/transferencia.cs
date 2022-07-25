using System.Text.Json.Serialization;

namespace transj
{
    public class transferencia
    {

        public new Guid id_transaccion { get; set; }


        public string num_cta { get; set; }

        public string cedula_cliente { get; set; }


        public DateTime fecha { get; set; }


        public decimal monto { get; set; }


        public string estado { get; set; }



        [JsonIgnore]
        public virtual cuenta? Cuenta { get; set; }
        [JsonIgnore]
        public virtual cliente? Cliente { get; set; }
    }
}
