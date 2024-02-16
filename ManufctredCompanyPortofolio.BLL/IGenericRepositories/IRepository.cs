using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManufctredCompanyPortofolio.BLL.IGenericRepositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> Exp, string IncludedProps = "");
        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> Exp, string IncludedProps = "");
        public Task Insert(T Entity);
        public Task Update(T Entity);
        public Task Delete(T Entity);        
        public Task Deatach(string KeyPropName, int KeyValue);
        public Task DeleteRange(IEnumerable<T> AllValues);
    }
}
