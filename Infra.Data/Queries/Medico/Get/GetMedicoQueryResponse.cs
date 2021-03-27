using System;

namespace Infra.Data.Queries.Medico.Get
{
    public class GetMedicoQueryResponse
    {
        public GetMedicoQueryResponse() { }

        public GetMedicoQueryResponse(Guid id, string nome, string regiao, string especialidade, string crm)
        {
            Id = id;
            Nome = nome;
            Regiao = regiao;
            Especialidade = especialidade;
            CRM = crm;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Regiao { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }
    }
}
