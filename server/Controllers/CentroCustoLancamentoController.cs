using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interface;
using server.Models;
using server.ModelsList;
using server.ModelsQuery;
using server.Shared.ComboBox;
using server.Shared.DataGrid;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroCustoLancamentoController(IMapper mapper)
    : CrudController<CentroCustoLancamento, CentroCustoLancamentoListQuery>
{
    [HttpGet("Filtrar")]
    public override ActionResult<dynamic> ListaFull([FromServices] Context context,
        [FromQuery] CentroCustoLancamentoListQuery query)
    {
        var filter = context.CentroCustoLancamento!
            .Include(x => x.Exercicio )
            .Include(x => x.CentroCusto)
            .Include(x => x.LancamentoTipo)
            .Include(x => x.ContaContabil)
            .Select(x => mapper.Map<CentroCustoLancamentoList>(x))
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable()
            .Filter(query).Sort(query);
            
        var dataGrid = new DataGrid(filter.CountAsync().Result , query.Pagination, query.PageNow, query.PageSize);

        if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
        dataGrid.DataContent( filter.ToListAsync().Result);
            
        return Ok(dataGrid);
    }
    

    [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroCustoLancamento!
                  .Include(x => x.LancamentoTipo)
                  .Include(x => x.Exercicio)
                  .Include(x => x.CentroCusto)
                  .Include(x => x.ContaContabil)
                  .FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            model.Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList();
            model.LancamentoTipos = context.LancamentoTipo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.ContaContabeis = context.ContaContabil!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroCustoLancamento
            {
                  CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList(),
                  Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList(),
                  LancamentoTipos = context.LancamentoTipo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  ContaContabeis = context.ContaContabil!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
    
    
    [HttpGet("Lancamentos")]
    public ActionResult<dynamic> Lancamentos([FromServices] Context context, [FromQuery] CentroCustoLancamentoQuery query)
    {
        var idCentroCusto = query.IdCentroCusto;
        var idExercicio = query.IdExercicio;
        var codigoOrcado = 3;
        var codigoReal = 4;
        var codigoForecast = 6;
        
        var listaLancamentoTipo = context.LancamentoTipo!
            .Where(x => x.Codigo.Equals(codigoOrcado) || x.Codigo.Equals(codigoReal) || x.Codigo.Equals(codigoForecast)).ToList();

        if (listaLancamentoTipo.Count != 3) return BadRequest("Tipo de Lançamento não encontrado, favor verificar! ");

        var filtroOrcado = new CentroCustoLancamentoQuery
        {
            IdCentroCusto = idCentroCusto,
            IdLancamentoTipo = listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoOrcado))!.Id,
            IdExercicio = idExercicio
        };
        
        var lancamentosOrcado = GetLancamentos(context, filtroOrcado);
        var lancamentosOrcadoTotais =  SumValuesCentroCustoLancamento(lancamentosOrcado.ToList(), listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoOrcado))!.Nome);
        
        
        var filtroReal = new CentroCustoLancamentoQuery
        {
            IdCentroCusto = idCentroCusto,
            IdLancamentoTipo = listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoReal))!.Id,
            IdExercicio = idExercicio
        };
        var lancamentosReal = GetLancamentos(context, filtroReal);
        var lancamentosRealTotais =  SumValuesCentroCustoLancamento(lancamentosReal.ToList(), listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoReal))!.Nome);
        
        
        var filtroForecast = new CentroCustoLancamentoQuery
        {
            IdCentroCusto = idCentroCusto,
            IdLancamentoTipo = listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoForecast))!.Id,
            IdExercicio = idExercicio
        };
        var lancamentosForecast = GetLancamentos(context, filtroForecast);
        var lancamentosForecastTotais =  SumValuesCentroCustoLancamento(lancamentosForecast.ToList(), listaLancamentoTipo.FirstOrDefault(x => x.Codigo.Equals(codigoForecast))!.Nome);

        
        var total = new List<CentroCustoLancamentoCampos>
        {
            lancamentosOrcadoTotais,
            lancamentosRealTotais,
            lancamentosForecastTotais
        };

        var fixas = new List<ICentroCustoLancamentoCampos>();
        fixas.AddRange(lancamentosOrcado.Where(x => x.CodigoContaContabilClassificacao != 5));
        fixas.AddRange(lancamentosReal.Where(x => x.DigitoContaContabil.Equals(0) && x.CodigoContaContabilClassificacao != 5).Select( x => mapper.Map<CentroCustoLancamentoCamposReal>(x)));
        fixas.AddRange(lancamentosForecast.Where(x => x.DigitoContaContabil.Equals(0) && x.CodigoContaContabilClassificacao != 5).Select( x => mapper.Map<CentroCustoLancamentoCamposForecast>(x)));
        
        
        var variaveis = new List<ICentroCustoLancamentoCampos>();
        variaveis.AddRange(lancamentosOrcado.Where(x => x.CodigoContaContabilClassificacao == 5));
        variaveis.AddRange(lancamentosReal.Where(x => x.DigitoContaContabil.Equals(0) && x.CodigoContaContabilClassificacao == 5).Select( x => mapper.Map<CentroCustoLancamentoCamposReal>(x)));
        variaveis.AddRange(lancamentosForecast.Where(x => x.DigitoContaContabil.Equals(0) && x.CodigoContaContabilClassificacao == 5).Select( x => mapper.Map<CentroCustoLancamentoCamposForecast>(x)));
        
        var dataContent = new CentroCustoLancamentoView
        {
            Total = total,
            Fixas = fixas.OrderBy(x => x.CodigoContaContabil).ThenBy(x => x.DigitoContaContabil).ThenBy(x => x.LancamentoTipo).ToList(),
            Variaveis = variaveis.OrderBy(x => x.CodigoContaContabil).ThenBy(x => x.DigitoContaContabil).ThenBy(x => x.LancamentoTipo).ToList()
        };
        
        return Ok(dataContent);
    }

    private List<CentroCustoLancamentoCampos> GetLancamentos(Context context, CentroCustoLancamentoQuery query)
    {
        return context.CentroCustoLancamento
            .Include(x => x.ContaContabil )
            .Include(x => x.ContaContabil!.ContaContabilClassificacao)
            .Include(x => x.ContaContabil!.ContaContabilFormula)
            .Include(x => x.LancamentoTipo)
            .Filter(query).Sort(query)
            .Select(x => ConvertTo(x))
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync().Result;
    }
    
    private static CentroCustoLancamentoCampos SumValuesCentroCustoLancamento(List<CentroCustoLancamentoCampos> list, string lancamentoTipo)
    {
        //return new CentroCustoLancamentoCampos();

        var valoresJaneiro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresJaneiro);
        var valoresFevereiro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresFevereiro);
        var valoresMarco = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresMarco);
        var valoresAbril = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresAbril);
        var valoresMaio = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresMaio);
        var valoresJunho = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresJunho);
        var valoresJulho = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresJulho);
        var valoresAgosto = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresAgosto);
        var valoresSetembro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresSetembro);
        var valoresOutubro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresOutubro);
        var valoresNovembro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresNovembro);
        var valoresDezembro = list.Where(x => x.DigitoContaContabil.Equals(0)).Sum(x => x.ValoresDezembro);
        
        return new CentroCustoLancamentoCampos
        {
            Id = 0,
            LancamentoTipo = lancamentoTipo,
            CodigoContaContabil = 0,
            DigitoContaContabil = 0,
            NomeContaContabil = null,
            LimiteContaContabil = null,
            HelpContaContabil = null,
            ValoresJaneiro = valoresJaneiro,
            ValoresFevereiro = valoresFevereiro,
            ValoresMarco = valoresMarco,
            ValoresAbril = valoresAbril,
            ValoresMaio = valoresMaio,
            ValoresJunho = valoresJunho,
            ValoresJulho = valoresJulho,
            ValoresAgosto = valoresAgosto,
            ValoresSetembro = valoresSetembro,
            ValoresOutubro = valoresOutubro,
            ValoresNovembro = valoresNovembro,
            ValoresDezembro = valoresDezembro,
            Total = (valoresJaneiro + valoresFevereiro + valoresMarco + valoresAbril + valoresMaio + valoresJunho + valoresJulho + valoresAgosto + valoresSetembro + valoresOutubro + valoresNovembro + valoresDezembro),
            Media = (valoresJaneiro + valoresFevereiro + valoresMarco + valoresAbril + valoresMaio + valoresJunho + valoresJulho + valoresAgosto + valoresSetembro + valoresOutubro + valoresNovembro + valoresDezembro) / 12,
            OrcadoReal = lancamentoTipo.Equals("orçado", StringComparison.InvariantCultureIgnoreCase) ? list.Sum(x =>x.OrcadoReal) : 0,
            OrcadoRealPorcento = lancamentoTipo.Equals("orçado", StringComparison.InvariantCultureIgnoreCase) ? list.Sum(x =>x.OrcadoRealPorcento) : 0,
            OrcadoForecast = lancamentoTipo.Equals("forecast", StringComparison.InvariantCultureIgnoreCase) ? list.Sum(x =>x.OrcadoForecast) : 0,
            OrcadoForecastPorcento = lancamentoTipo.Equals("forecast", StringComparison.InvariantCultureIgnoreCase) ? list.Sum(x =>x.OrcadoForecastPorcento) : 0,
            FormulaContaContabil = null,
            CodigoContaContabilClassificacao = 0
        };
        
    }
    private static CentroCustoLancamentoCampos ConvertTo(CentroCustoLancamento x)
    {
        return new CentroCustoLancamentoCampos
        {
            Id = x.Id,
            LancamentoTipo = x.LancamentoTipo!.Nome,
            CodigoContaContabil = x.ContaContabil!.Codigo,
            DigitoContaContabil = x.ContaContabil.Digito,
            NomeContaContabil = x.ContaContabil.Nome,
            LimiteContaContabil = x.ContaContabil.Limite,
            HelpContaContabil = x.ContaContabil.Help,
            ValoresJaneiro = x.ValoresJaneiro,
            ValoresFevereiro = x.ValoresFevereiro,
            ValoresMarco = x.ValoresMarco,
            ValoresAbril = x.ValoresAbril,
            ValoresMaio = x.ValoresMaio,
            ValoresJunho = x.ValoresJunho,
            ValoresJulho = x.ValoresJulho,
            ValoresAgosto = x.ValoresAgosto,
            ValoresSetembro = x.ValoresSetembro,
            ValoresOutubro = x.ValoresOutubro,
            ValoresNovembro = x.ValoresNovembro,
            ValoresDezembro = x.ValoresDezembro,
            Total = 100,
            Media = 50,
            OrcadoReal = 20,
            OrcadoRealPorcento = 10,
            OrcadoForecast = 20,
            OrcadoForecastPorcento = 10,
            FormulaContaContabil = x.ContaContabil.ContaContabilFormula!.Formula,
            CodigoContaContabilClassificacao = x.ContaContabil.ContaContabilClassificacao!.Codigo
        };
    }
}