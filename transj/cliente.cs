using FluentValidation;
using System.Text.Json.Serialization;

namespace transj
{
    public class cliente
    {
        public string cedula_cliente { get; set; }


        public string tipo_doc { get; set; }

        public string nombre_apellido { get; set; }



      
        public virtual ICollection<cuenta> Cuentas { get; set; } = new List<cuenta>();


        [JsonIgnore]
        public virtual ICollection<transferencia> Transferencias { get; set; } = new List<transferencia>();
    }



}

