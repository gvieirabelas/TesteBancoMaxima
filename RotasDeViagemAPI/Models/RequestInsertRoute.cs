using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotasDeViagemAPI.Models
{
    public class RequestInsertRoute
    {
        public Rota Rota { get; set; }
        public string Location { get; set; }
    }
}
