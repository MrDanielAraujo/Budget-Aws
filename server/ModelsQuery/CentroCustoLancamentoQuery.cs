using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using server.Shared.DataGrid;

namespace server.ModelsQuery;


public class CentroCustoLancamentoListQuery : IDataGrid
{
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public long? Id { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public string? Tipo { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public string? CentroCusto { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public string? Exercicio { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public string? ContaContabil { get; set; }
    
    public int PageNow { get; set; }
    public int PageSize { get; set; }
    public bool Pagination { get; set; }
    
    public string? Sort { get; set; }
}

public class CentroCustoLancamentoQuery : IDataGrid
{
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public long? Id { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public long? IdLancamentoTipo { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public long? IdCentroCusto { get; set; }
    
    [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
    public long? IdExercicio { get; set; }
    
    public int PageNow { get; set; }
    public int PageSize { get; set; }
    public bool Pagination { get; set; }
    
    public string? Sort { get; set; }
}