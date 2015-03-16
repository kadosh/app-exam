using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppProgramming.DataModel.Models;

namespace AppProgramming.DataModel.Repositories
{
    interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> Query(Dictionary<string, string> queryItems);
        IEnumerable<T> Query(Dictionary<string, string> queryItems, bool approachMode);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        IEnumerable<T> ListAll();
    }
}
