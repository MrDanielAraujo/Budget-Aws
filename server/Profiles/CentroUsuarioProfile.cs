using AutoMapper;
using server.Models;
using server.ModelsList;

namespace server.Profiles;

public class CentroUsuarioProfile : Profile
{
    public CentroUsuarioProfile()
    {
        CreateMap<CentroCustoUsuario, CentroUsuarioList>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(p => p.Email))
            .ForMember(dest => dest.Centro, opt => opt.MapFrom(p => p.CentroCusto!.Nome));
    }
    
}