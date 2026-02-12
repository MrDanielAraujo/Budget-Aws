using AutoMapper;
using server.Models;
using server.ModelsList;

namespace server.Profiles;

public class CentroLancamentoProfile : Profile
{
    public CentroLancamentoProfile()
    {
        CreateMap<CentroCustoLancamento, CentroCustoLancamentoList>()
            .ForMember(pvm => pvm.Exercicio, options => options.MapFrom(p => p.Exercicio!.Ano))
            .ForMember(pvm => pvm.CentroCusto, options => options.MapFrom(p => p.CentroCusto!.Nome))
            .ForMember(pvm => pvm.ContaContabil, options => options.MapFrom(p => p.ContaContabil!.Nome))
            .ForMember(pvm => pvm.Tipo, options => options.MapFrom(p => p.LancamentoTipo!.Nome));

        CreateMap<CentroCustoLancamentoCampos, CentroCustoLancamentoCamposReal>()
            .ForMember(pvm => pvm.DigitoContaContabil, options => options.MapFrom(s => 99));

        CreateMap<CentroCustoLancamentoCampos, CentroCustoLancamentoCamposForecast>()
            .ForMember(pvm => pvm.DigitoContaContabil, options => options.MapFrom(s => 98));

    }
}