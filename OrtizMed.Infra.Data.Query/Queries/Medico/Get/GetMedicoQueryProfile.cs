using AutoMapper;

namespace OrtizMed.Infra.Data.Query.Queries.Medico.Get
{
    public class GetMedicoQueryProfile : Profile
    {
        public GetMedicoQueryProfile()
        {
            CreateMap<OrtizMed.Domain.Entities.Medico, GetMedicoQueryResponse>(MemberList.None);
        }
    }
}
