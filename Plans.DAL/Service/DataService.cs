using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plans.Domain;
using Plans.Domain.Model;
using Plans.Domain.Model.Tabulator;
using Plans.Domain.Service;

namespace Plans.DAL.Service
{
    public abstract class DataService<TEntity, TEntityVM> : IDataService<TEntity, TEntityVM> where TEntity : class, IEntity
    {
        protected DbContext dbContext;

        public DataService(IContextService service)
        {
            dbContext = (DbContext)service;
        }

        protected abstract IQueryable<TEntityVM> ApplyFilter(List<Dictionary<string, string>> filters);

        public async Task<PaginationResponse<TEntityVM>> Get(int page, int size, List<Dictionary<string, string>> filters, List<Dictionary<string, string>> sorters)
        {
            // todo Expression
            var data = ApplyFilter(filters);
            if (sorters != null)
            {
                sorters.Reverse();
                foreach (var sorter in sorters)
                {
                    var pi = typeof(TEntityVM).GetProperty(sorter["field"]);
                    data = sorter["dir"] == "asc" ? data.OrderBy(e => pi.GetValue(e)) : data.OrderByDescending(e => pi.GetValue(e));
                }
            }

            return new PaginationResponse<TEntityVM>
            {
                LastPage = (int)Math.Ceiling(data.Count() / (double)Constants.PageSize),
                Data = await data.Skip(page < 1 ? 0 : (page - 1) * size).Take(size).ToListAsync()
            };
        }

        public async Task<TEntity[]> Save(TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id < 1)
                {
                    dbContext.Attach(entity);
                }
                else
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            await dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task Delete(long[] ids)
        {
            var set = dbContext.Set<TEntity>();
            foreach (var id in ids)
            {
                var entity = await set.FindAsync(id);
                if (entity != null)
                {
                    set.Remove(entity);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        protected string GetFilterValue(List<Dictionary<string, string>> filters, string name)
        {
            return filters.FirstOrDefault(f => f["field"] == name)?["value"];
        }
    }
}
