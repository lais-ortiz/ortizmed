using AutoMapper;
using System.Collections.Generic;

namespace Infra.Data.Queries.Medico.Get
{
    public class GetMedicoQueryProfile : Profile
    {
        public GetMedicoQueryProfile()
        {
            CreateMap<OrtizMed.Domain.Entities.Medico, GetMedicoQueryResponse>(MemberList.None);
        }
    }
}
