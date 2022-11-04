using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.DAL
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Delete(T entity);
    }
}
