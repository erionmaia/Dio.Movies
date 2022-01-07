using System.Collections.Generic;

namespace Dio.Movies.Interfaces
{
    public interface IRepository<T>
    {
         List<T> List();
         T ReturnByCod(int cod);
         void Insert(T entity);
         void Delete(int cod);
         void Update(int cod, T entity);
         int NextCod();
    }
}