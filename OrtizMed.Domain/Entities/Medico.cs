using System;

namespace OrtizMed.Domain.Entities
{
    public class Medico
    {
        public Medico() { }

        public Medico(Guid id, string nome, string regiao, string especialidade, string crm)
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
