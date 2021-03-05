using CsvHelper.Configuration;
using RotasDeViagemAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotasDeViagemAPI.Mappers
{
    public class RotaMapper: ClassMap<Rota>
    {
        public RotaMapper()
        {
            Map(c => c.Origem).Name("Origem");
            Map(c => c.Destino).Name("Destino");
            Map(c => c.Valor).Name("Valor");

        }
    }
}
