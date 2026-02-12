using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class ComboInformacoesQuery : IDataGrid
{
      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? Id { get; set; }

      [QueryOperator(Operator = WhereOperator.Contains)]
      public string? Nome { get; set; }
      
      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? IdCentroCusto { get; set; }
      
      [QueryOperator(Operator = WhereOperator.EqualsWhenNullable)]
      public long? IdComboInformacoesSeparacao { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}