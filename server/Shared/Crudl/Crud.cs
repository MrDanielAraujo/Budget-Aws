using System.Linq.Expressions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Shared.DataGrid;

namespace server.Shared.Crudl;

public static class Crud
{
      
      public static DataGrid.DataGrid ToGrid<T>(this Context context, IDataGrid query, Expression<Func<T, dynamic>> select ) where T : class
      {
            var filter = context.Set<T>().AsQueryable().Filter(query).Sort(query);
            
            var dataGrid = new DataGrid.DataGrid( filter.CountAsync().Result , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent(  filter.Select(select).ToListAsync().Result );
            
            return dataGrid;
      }
      
      public static DataGrid.DataGrid ToGrid<T>(this Context context, IDataGrid query ) where T : class
      {
            Console.WriteLine(query);
            
            var filter = context.Set<T>().AsQueryable().Filter(query).Sort(query);
            
            var dataGrid = new DataGrid.DataGrid( filter.CountAsync().Result , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent( filter.ToListAsync().Result);
            
            return dataGrid;
      }

      public static dynamic? Read<T>(this Context context,  long id ) where T : class
      {
            return context.Set<T>().Find(id);
      }

      public static (bool, string)  SaveCreate<T>(this Context context, T classe) where T : class
      {
            try
            {
                  context.Set<T>().Add(classe);
                  context.SaveChanges();
            }
            catch (UniqueConstraintException)
            {
                  return (false, "uniquekey");
            }
            catch (Exception)
            {
                  return (false, "fail");
            }
            
            return (true, "success");
      }

      public static (bool, string) SaveUpdate<T>(this Context context, T classe) where T : class
      {
            try
            {
                  context.Set<T>().Attach(classe);
                  context.Entry(classe).State = EntityState.Modified;
                  context.SaveChanges();
            }
            catch (UniqueConstraintException)
            {
                  return (false, "uniquekey");
            }
            catch (Exception)
            {
                  return (false, "fail");
            }
            
            return (true, "success");
      }

      public static bool SaveRemove<T>(this Context context, string ids) where T : class
      {
            if (string.IsNullOrEmpty(ids)) return false;
            
            var table = typeof(T).Name;
            
            using var transaction = context.Database.BeginTransaction();
            try
            {
                  var where = ids.Split(',').Length <= 1 ? $"WHERE Id = {ids}" : $"WHERE Id IN ({ids})";

                  var query = $"DELETE FROM {table} {where};";
                  
                  context.Database.ExecuteSqlRaw(query);
                  
                  transaction.Commit();
            }
            catch (Exception)
            {
                  transaction.Rollback();
                  return false;
            }

            return true;
      }
}