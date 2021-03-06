using MediatR;
using System.Collections.Generic;

namespace OrtizMed.Infra.Data.Query.Queries.Medico.Get
{
    public class GetMedicoQuery : IRequest<IEnumerable<GetMedicoQueryResponse>>
    {
        public GetMedicoQuery() { }

        public GetMedicoQuery(FiltroPesquisa tipoFiltro, string filtro)
        {
            TipoFiltro = tipoFiltro;
            Filtro = filtro;
        }

        public FiltroPesquisa TipoFiltro { get; set; }
        public string Filtro { get; set; }
    }
}
