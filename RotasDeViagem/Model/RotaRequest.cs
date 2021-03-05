using RotasDeViagem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotasDeViagemAplication.Model
{
    public class RotaRequest
    {
        public Rota InitialRota { get; set; }
        public List<Rota> Rotas { get; set; }
        public string Location { get; set; }
    }
}
