using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotasDeViagemAPI.Models
{
    public class RequestRoute
    {
        public Rota InitialRota { get; set; }
        public List<Rota> Rotas { get; set; }
        public string Location { get; set; }
    }
}
