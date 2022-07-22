using System.Text.Json.Serialization;

namespace transj
{
    public class cuenta
    {
        public Guid id_cta { get; set; }

        public string num_cta { get; set; }

        public string moneda { get; set; }

        public string cedula_cliente { get; set; }

        public decimal saldo { get; set; }

       
        public string cod_banco { get; set; }


        [JsonIgnore]
        public virtual cliente? Cliente { get; set; } 
        [JsonIgnore]
        public virtual banco? Banco { get; set; } 

        [JsonIgnore]
        public virtual ICollection<transferencia> Transferencias { get; set; } = new List<transferencia>();
    }
}
