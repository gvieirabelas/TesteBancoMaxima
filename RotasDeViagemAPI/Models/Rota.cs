using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotasDeViagemAPI.Models
{
    public class Rota
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
    }
}
