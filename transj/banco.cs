using System.Text.Json.Serialization;

namespace transj
{
    public class banco
    {
        public string cod_banco { get; set; }

        public string nombre_banco { get; set; }


        public string direccion { get; set; }


        [JsonIgnore]
        public virtual ICollection<cuenta> Cuentas { get; set; } = new List<cuenta>();  


    }
}
