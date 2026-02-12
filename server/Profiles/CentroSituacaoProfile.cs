using AutoMapper;
using server.Models;
using server.ModelsList;

namespace server.Profiles;

public class CentroSituacaoProfile : Profile
{
    public CentroSituacaoProfile()
    {
        CreateMap<CentroCustoSituacao, CentroSituacaoList>()
            .ForMember(pvm => pvm.Exercicio, options => options.MapFrom(p => p.Exercicio!.Ano))
            .ForMember(pvm => pvm.Centro, options => options.MapFrom(p => p.CentroCusto!.Nome));
        
        CreateMap<CentroLucroSituacao, CentroSituacaoList>()
            .ForMember(pvm => pvm.Exercicio, options => options.MapFrom(p => p.Exercicio!.Ano))
            .ForMember(pvm => pvm.Centro, options => options.MapFrom(p => p.CentroLucro!.Nome));
    }
}