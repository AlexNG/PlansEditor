using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plans.Domain.Model.Tabulator;
using Plans.Domain.Service;

namespace PlansEditor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController<TEntity, TEntityVM> : ControllerBase
    {
        private IDataService<TEntity, TEntityVM> dataService;

        public EntityController(IDataService<TEntity, TEntityVM> dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<TEntityVM>>> Get(int page, int size, [FromQuery]List<Dictionary<string, string>> filters, [FromQuery]List<Dictionary<string, string>> sorters) =>
            Ok(await dataService.Get(page, size, filters, sorters));

        [HttpPost]
        public async Task<ActionResult<TEntity[]>> Post([FromBody] TEntity[] entities)
        {
            return Ok(await dataService.Save(entities));
        }

        [HttpPut]
        public async Task Put([FromBody] TEntity[] entities)
        {
            await dataService.Save(entities);
        }

        [HttpDelete]
        public async Task Delete(long[] ids)
        {
            await dataService.Delete(ids);
        }
    }
}
