using AutoMapper;
using server.Models;

namespace server.Profiles;

public class HomeCentroProfile: Profile
{
    
    public HomeCentroProfile()
    {

        CreateMap<CentroCustoSituacao, HomeCentroCusto>()
            .ForMember(dest => dest.IdExercicio, opt => opt.MapFrom(p => p.Exercicio!.Id))
            .ForMember(dest => dest.IdCentro, opt => opt.MapFrom(p => p.CentroCusto!.Id))
            .ForMember(dest => dest.CentroCodigo, opt => opt.MapFrom(p => p.CentroCusto!.Codigo))
            .ForMember(dest => dest.CentroNome, opt => opt.MapFrom(p => p.CentroCusto!.Nome))
            .ForMember(dest => dest.Situacao, opt => opt.MapFrom(p => p.CentroStatu!.Nome))
            .ForMember(dest => dest.SituacaoBgColor, opt => opt.MapFrom(p => p.CentroStatu!.BgColor))
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroCustoUsuario!.Email) ? "---" : p.CentroCustoUsuario!.Email))
            .ForMember(dest => dest.NivelAtual, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroCustoUsuario!.Nivel.ToString()) ? 0 : p.CentroCustoUsuario!.Nivel))
            .ForMember(dest => dest.NivelTotal, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroCusto!.NivelTotal.ToString()) ? 0 : p.CentroCusto!.NivelTotal));
        
        CreateMap<CentroLucroSituacao, HomeCentroLucro>()
            .ForMember(dest => dest.IdExercicio, opt => opt.MapFrom(p => p.Exercicio!.Id))
            .ForMember(dest => dest.IdCentro, opt => opt.MapFrom(p => p.CentroLucro!.Id))
            .ForMember(dest => dest.CentroCodigo, opt => opt.MapFrom(p => p.CentroLucro!.Codigo))
            .ForMember(dest => dest.CentroNome, opt => opt.MapFrom(p => p.CentroLucro!.Nome))
            .ForMember(dest => dest.Situacao, opt => opt.MapFrom(p => p.CentroStatu!.Nome))
            .ForMember(dest => dest.SituacaoBgColor, opt => opt.MapFrom(p => p.CentroStatu!.BgColor))
            .ForMember(dest => dest.Usuario, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroLucroUsuario!.Email) ? "---" : p.CentroLucroUsuario!.Email))
            .ForMember(dest => dest.NivelAtual, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroLucroUsuario!.Nivel.ToString()) ? 0 : p.CentroLucroUsuario!.Nivel))
            .ForMember(dest => dest.NivelTotal, opt => opt.MapFrom(p => string.IsNullOrEmpty(p.CentroLucro!.NivelTotal.ToString()) ? 0 : p.CentroLucro!.NivelTotal));
    }
    
}