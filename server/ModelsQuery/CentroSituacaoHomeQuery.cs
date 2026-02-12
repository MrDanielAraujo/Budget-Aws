using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using server.Models;
using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class CentroSituacaoHomeQuery : IDataGrid
{
      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? Id { get; set; }

      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? IdCentro { get; set; }

      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? IdExercicio { get; set; }

      public string? Exercicio { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? CentroCodigo { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? CentroNome { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? Usuario { get; set; }

      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public int? NivelAtual { get; set; }

      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public int? NivelTotal { get; set; }

      public string? Situacao { get; set; }

      public string? CentroTipo { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}