using ManufctredCompanyPortofolio.BLL.IGenericRepositories;
using ManufuctredCompanyPortofolio.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ManufuctredCompanyPortofolio.BL.GenericRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Delete(T Entity)
        {
            context.Entry<T>(Entity).State = EntityState.Deleted;            
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> Exp, string IncludedProps = "")
        {
            var Set = context.Set<T>().Where(Exp);
            if (IncludedProps != "")
            {
                foreach (string prop in IncludedProps.Split(','))
                {
                    Set = Set.Include(prop);
                }
            }
            Debug.WriteLine(typeof(T).FullName);
            return await Set.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> Exp, string IncludedProps = "")
        {
            var record = context.Set<T>().Where(Exp);
            if (IncludedProps != "")
            {
                foreach (string prop in IncludedProps.Split(','))
                {
                    record = record.Include(prop);
                }
            }
            return await record.FirstOrDefaultAsync();
        }

        public async Task Insert(T Entity)
        {
            context.AddAsync(Entity);
        }

        

        public async Task Update(T Entity)
        {
            context.Entry<T>(Entity).State =EntityState.Modified;
        }


        public async Task Deatach(string keyPropName, int keyValue)
        {
            foreach (var dbEntityEntry in context.ChangeTracker.Entries().ToList())
            {
                if (dbEntityEntry.Entity is T entity)
                {
                    var keyProperty = entity.GetType().GetProperty(keyPropName);

                    if (keyProperty != null)
                    {
                        var keyPropertyValue = keyProperty.GetValue(entity);

                        if (keyPropertyValue != null && Convert.ToInt32(keyPropertyValue) == keyValue)
                        {
                            dbEntityEntry.State = EntityState.Detached;
                            break;
                        }
                    }
                }
            }
        }



        public async Task DeleteRange(IEnumerable<T> AllValues)
        {
            context.RemoveRange(AllValues);
        }

       
    }
}
