using CsvHelper.Configuration;
using RotasDeViagem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotasDeViagem.Mappers
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
