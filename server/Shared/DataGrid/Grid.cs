using System.Collections;

namespace server.Shared.DataGrid;

public class Grid
{
      public int PagePrevious { get; set; }

      public int PageNext { get; set; }

      public int PageCount { get; set; }

      public int PageNow { get; set; }

      public int PageSize { get; set; }

      public int RegCount { get; set; }

      public List<int?> Pages { get; set; } = new();

      public IEnumerable? Data { get; set; }

      protected int Skip { get; set; }
}