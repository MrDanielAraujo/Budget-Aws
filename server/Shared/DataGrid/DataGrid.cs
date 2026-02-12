using System.Collections;

namespace server.Shared.DataGrid;

public class DataGrid : Grid
{
      public DataGrid(int count, bool pagination, int? pageNow = 1, int? pageSize = 1)
      {
            PageNow = pageNow ?? 1;
            RegCount = count;
            PageSize = pageSize ?? 1;
            if (!pagination) return;
            CalcularPageCount();
            CalcularPageNow();
            CalcularSkip();
            CalcularPagePrevious();
            CalcularPageNext();
            CalcularPageBar();
      }

      public void DataContent(IEnumerable? data = null)
      {
            Data = data;
      }

      public int GetSkip()
      {
            return Skip;
      }
      
      private void CalcularSkip()
      {
            Skip = (PageSize is >= 1)? (PageNow - 1) * PageSize : 0;
            if (Skip < 0) Skip = 0;
      }
      
      private void CalcularPageCount()
      {
            PageCount = RegCount / PageSize;
            if (RegCount % PageSize > 0) PageCount++;
      }
      
      private void CalcularPageNow()
      {
            PageNow = PageNow <= 0 ? 1 : PageNow;
            if (PageNow > PageCount) PageNow = PageCount;
      }
      
      private void CalcularPagePrevious()
      {
            PagePrevious = (PageNow - 1 <= 0 ? 1 : PageNow - 1);
      }
      
      private void CalcularPageNext()
      {
            PageNext = PageNow + 1 > PageCount ? PageCount : PageNow + 1;
      }
      
      private void CalcularPageBar()
      {
            Pages = new List<int?>();

            if (PageCount < 2 ) return;

            for (var pageAnt = PageNow - 2; pageAnt <= PageNow - 1; pageAnt++)
                  if (pageAnt >= 1) Pages.Add(pageAnt);

            Pages.Add(PageNow);

            for (var pageDep = PageNow + 1; pageDep <= PageNow + 2; pageDep++)
                  if (pageDep <= PageCount) Pages.Add(pageDep);
      }
}