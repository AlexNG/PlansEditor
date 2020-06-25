using Plans.DAL.Model;
using Plans.Domain.Service;

namespace PlansEditor.Controllers
{
    public class PlanController : EntityController<Plan, PlanVM>
    {
        public PlanController(IDataService<Plan, PlanVM> dataService) : base(dataService)
        {
        }
    }
}
