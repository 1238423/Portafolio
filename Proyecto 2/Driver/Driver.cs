using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blockchain.Models;
using RestSharp;

namespace Driver
{
    public class BlockchainConnector
    {
        private static readonly string url = "https://proyecto2-api.azurewebsites.net";
        private static readonly RestClient _httpClient = new RestClient(new RestClientOptions(url));

        public static string[] ActualizarDpis()
        {
            var dpis = _httpClient.Get(new RestRequest("/"));
            return JsonSerializer.Deserialize<string[]>(dpis.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static string[,] CandidatosPresidentes()
        {
            var presidentsData = _httpClient.GetJson<CandidatePresident[]>("/canditates/presidents");
            if(presidentsData is null) return null;

            var data = new string[presidentsData.Length, 4];
            for (int i = 0; i < presidentsData.Length; i++)
            {
                var president = presidentsData.ElementAt(i);
                data[i, 0] = president.Id.ToString();
                data[i, 1] = president.Name;
                data[i, 2] = president.Partido;
                data[i, 3] = president.VicePresident;
            }
            return data;
        }

        public static string[,] CandidatosDiputados()
        {
            var deputiesData = _httpClient.GetJson<CandidateDeputy[]>("/canditates/deputies");
            if (deputiesData is null) return null;

            var data = new string[deputiesData.Count(), 4];
            for (int i = 0; i < deputiesData.Count(); i++)
            {
                var president = deputiesData.ElementAt(i);
                data[i, 0] = president.Id.ToString();
                data[i, 1] = president.Name;
                data[i, 2] = president.Partido;
                data[i, 3] = president.Departamento;
            }
            return data;
        }

        public static string[] RegistrarVoto(string DPI, Guid? presidenteId, Guid? diputadoId, string estudiante)
        {
            if (presidenteId is null) return null;
            if (diputadoId is null) return null;
            if (string.IsNullOrEmpty(DPI)) return null;
            if (string.IsNullOrEmpty(estudiante)) return null;

            try
            {
                Block vote = new Block();
                vote.Dpi = DPI;
                vote.Presidente = (Guid)presidenteId;
                vote.Diputado = (Guid)diputadoId;
                vote.node = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(System.Net.Dns.GetHostName()));
                var response = _httpClient.PostJson("/", vote);
                if (response.Equals(HttpStatusCode.OK))
                {
                    return ActualizarDpis();
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}