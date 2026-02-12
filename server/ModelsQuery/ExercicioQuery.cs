using server.Shared.DataGrid;

namespace server.ModelsQuery;

public class ExercicioQuery : IDataGrid
{
      public long? Id { get; set; }

      public string? Ano { get; set; }

      public bool? Aberto { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public bool Pagination { get; set; }

      public string? Sort { get; set; }
}