using AutoMapper;
using MediatR;
using OrtizMed.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrtizMed.Infra.Data.Query.Queries.Medico.Get
{
    public class GetMedicoQueryHandler : IRequestHandler<GetMedicoQuery, IEnumerable<GetMedicoQueryResponse>>
    {
        private readonly IFirebaseServiceClient _firebaseServiceClient;
        private readonly IMapper _mapper;

        public GetMedicoQueryHandler(IFirebaseServiceClient firebaseServiceClient, IMapper mapper)
        {
            _firebaseServiceClient = firebaseServiceClient;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMedicoQueryResponse>> Handle
            (GetMedicoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var firebaseResponse = await _firebaseServiceClient.GetMedicos();

                var medicos = _mapper.Map<IEnumerable<OrtizMed.Domain.Entities.Medico>, IEnumerable<GetMedicoQueryResponse>>(firebaseResponse);

                return !string.IsNullOrEmpty(request.Filtro) ?
                    Filtrar(medicos, request.TipoFiltro, request.Filtro) :
                    medicos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private List<GetMedicoQueryResponse> Filtrar(IEnumerable<GetMedicoQueryResponse> medicos, FiltroPesquisa tipoFiltro, string filtro)
        {
            return medicos.Where(medico => 
            {
                if (tipoFiltro == FiltroPesquisa.Nome) return medico.Nome == filtro;
                else if (tipoFiltro == FiltroPesquisa.Regiao) return medico.Regiao == filtro;
                else if (tipoFiltro == FiltroPesquisa.Especialidade) return medico.Especialidade == filtro;
                else return false;
            }).ToList();
        }
    }
}
