using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrtizMed.Domain.Entities;
using OrtizMed.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrtizMed.Service.Firebase
{
    public class FirebaseServiceClient : IFirebaseServiceClient
    {
        static readonly HttpClient client = new HttpClient();

        public FirebaseServiceClient()
        {
            SetHttpConfigurations();
        }

        private void SetHttpConfigurations()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public async Task<IEnumerable<Medico>> GetMedicos()
        {
            try
            {
                var medicos = new List<Medico>();

                var response = await client.GetAsync("https://ortiz-med-default-rtdb.firebaseio.com/medicos/.json");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonMedicos = JObject.Parse(responseBody).Values().ToList();

                jsonMedicos.ForEach(jsonMedico =>
                {
                    var medico = jsonMedico.ToObject<Medico>();
                    medicos.Add(new Medico(medico.Id, medico.Nome, medico.Regiao, medico.Especialidade, medico.CRM));
                });

                return medicos;
            }
            catch (Exception ex)
            {

                throw;
            }

            //var repositories = await JsonSerializer.DeserializeAsync<List<object>>(await streamTask);
        }
    }
}
