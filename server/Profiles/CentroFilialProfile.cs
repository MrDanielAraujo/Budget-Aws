using AutoMapper;
using server.Models;
using server.ModelsList;

public class CentroFilialProfile : Profile
{
    public CentroFilialProfile()
    {
        CreateMap<CentroFilial, CentroFilialList>()
            .ForMember(pvm => pvm.Empresa, options => options.MapFrom(p => p.Empresa!.NomeReal));
    }
}