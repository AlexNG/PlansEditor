using Plans.DAL.Model;
using Plans.Domain.Service;

namespace PlansEditor.Controllers
{
    public class EventController : EntityController<Event, Event>
    {
        public EventController(IDataService<Event, Event> dataService) : base(dataService)
        {
        }
    }
}
