using System.Collections.Generic;
using System.Threading.Tasks;
using Plans.Domain.Model.Tabulator;

namespace Plans.Domain.Service
{
    public interface IDataService<TEntity, TEntityVM>
    {
        Task<PaginationResponse<TEntityVM>> Get(int page, int size, List<Dictionary<string, string>> filters, List<Dictionary<string, string>> sorters);

        Task<TEntity[]> Save(TEntity[] entities);

        Task Delete(long[] ids);
    }
}
