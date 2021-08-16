using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Servicios_WCF.Class
{
    [DataContract] // para que no se serialice en orden alfabetico
    public class Medicamento_class
    {
        [DataMember(Order = 0)]
        public int IIDMEDICAMENTO { get; set; }
        [DataMember(Order = 1)]
        public string NOMBRE { get; set; }
        [DataMember(Order = 2)]
        public string CONCENTRACION { get; set; }
        [DataMember(Order = 3)]
        public int IIDFORMAFARMACEUTICA { get; set; }
        [DataMember(Order = 4)]
        public string NOMBREFORMAFARMACEUTICA { get; set; }
        [DataMember(Order = 5)]
        public decimal PRECIO { get; set; }
        [DataMember(Order = 6)]
        public int STOCK { get; set; }
        [DataMember(Order = 7)]
        public string PRESENTACION { get; set; }
        [DataMember(Order = 8)]
        public int BHABILITADO { get; set; }

    }
}