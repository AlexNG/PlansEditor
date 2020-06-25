using System.Collections.Generic;
using System.Linq;
using Plans.DAL.Model;
using Plans.Domain.Service;

namespace Plans.DAL.Service
{
    public class PlanService : DataService<Plan, PlanVM>
    {
        public PlanService(IContextService service) : base(service) { }

        protected override IQueryable<PlanVM> ApplyFilter(List<Dictionary<string, string>> filters)
        {
            IQueryable<PlanVM> data = dbContext.Set<PlanVM>();

            string name = GetFilterValue(filters, nameof(PlanVM.Name));
            if (!string.IsNullOrWhiteSpace(name))
            {
                data = data.Where(p => p.Name.Contains(name));
            }

            string descr = GetFilterValue(filters, nameof(PlanVM.Description));
            if (!string.IsNullOrWhiteSpace(descr))
            {
                data = data.Where(p => p.Description.Contains(descr));
            }

            return data;
        }
    }
}
