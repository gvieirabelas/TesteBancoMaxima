using CsvHelper;
using CsvHelper.Configuration;
using RotasDeViagemAPI.Mappers;
using RotasDeViagemAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagemAPI.Service
{
    public class RotaService
    {
        public RotaService()
        {

        }
        public ResponseRoute FindBestWay(Rota rotaInicial, List<Rota> listRotas)
        {
            ArrayList arrayRota = new ArrayList(listRotas);
            List<ResponseRoute> suggestions = new List<ResponseRoute>();
            var newList = new List<Rota>(); ;
            var initial = listRotas.Where(x => x.Origem == rotaInicial.Origem).ToList();
            foreach( var i in initial)
            {
                newList = new List<Rota>();
                ResponseRoute suggestion= new ResponseRoute();
                var rotaFinal = FindNextWay(rotaInicial,i, listRotas, newList);
                
                suggestion.OrigemConcat = ConcatString(rotaFinal);
                suggestion.Valor = rotaFinal.Sum(y => y.Valor);
                suggestions.Add(suggestion); 
            }
            var min = suggestions.Where(x => suggestions.Min(y => y.Valor) == x.Valor).FirstOrDefault();
            return min;


        }
        public List<Rota> FindNextWay(Rota rotaInicial,Rota rotaNext, List<Rota> listRotas,List<Rota> newList)
        {
            ArrayList arrayRota = new ArrayList(listRotas);
            if ((rotaInicial.Origem == rotaNext.Origem )&&(rotaInicial.Destino == rotaInicial.Destino))
                newList.Add(rotaNext);
            var initial = listRotas.Where(x => x.Origem == rotaNext.Destino).ToList();
            foreach (var i in initial)
            {
                newList.Add(i);
                if (i.Destino != rotaInicial.Destino)
                    FindNextWay(rotaInicial,i, listRotas, newList);
            }
            return newList;
        }
        public string ConcatString(List<Rota> list)
        {
            string result = "";
            foreach(var obj in list)
            {
                if (obj == list.First())
                    result += string.Concat(obj.Origem,"-",obj.Destino);
                else
                    result += string.Concat("-", obj.Destino);
            }
            return result;
        }
        public List<Rota>getArquivo(string location)
        {
            try
            {
                using (TextReader reader = new StreamReader(location, Encoding.Default))
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<RotaMapper>();
                    var records = csv.GetRecords<Rota>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string SetRoute(RequestInsertRoute insert)
        {
            try
            {

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    NewLine = NewLine.CRLF,
                    HasHeaderRecord = false,
                };
                using (var stream = File.Open(insert.Location, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.NextRecord();
                    csv.WriteRecord<Rota>(insert.Rota);
                }

                return "Concluído com sucesso";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
