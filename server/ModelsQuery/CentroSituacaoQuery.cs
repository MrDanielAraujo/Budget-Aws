using server.Models;
using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class CentroSituacaoQuery : IDataGrid
{
      public long? Id { get; set; }

      //public long? IdExercicio { get; set; }
      public string? Exercicio { get; set; }

      public string? Centro { get; set; }
      //public long? IdCentroCusto { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}