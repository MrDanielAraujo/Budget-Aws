using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Profiles;

public class HomeCentroCustoAction  : IMappingAction<Source, Destination> 
{
    private readonly Context _context;

    public HomeCentroCustoAction(Context context)
    {
        _context = context;
    }

    public DestinationProperty Resolve(Source source, Destination destination, DestinationProperty destMember, ResolutionContext context)
    {
        // Aqui você pode usar o _context para acessar dados
       
        return someData.SomeProperty;
    }

    public void Process(Source source, Destination destination, ResolutionContext context)
    {
        var someData = _context!.CentroCustoUsuario!.Where(y => y.IdCentroCusto == source.IdCentroCusto).GroupBy(y => y.IdCentroCusto).Count();
        
        destination.
    }
}
}