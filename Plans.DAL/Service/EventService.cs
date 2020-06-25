using System.Collections.Generic;
using System.Linq;
using Plans.DAL.Model;
using Plans.Domain.Service;

namespace Plans.DAL.Service
{
    public class EventService : DataService<Event, Event>
    {
        public EventService(IContextService service) : base(service)
        {
        }

        protected override IQueryable<Event> ApplyFilter(List<Dictionary<string, string>> filters)
        {
            return dbContext.Set<Event>();
        }
    }
}
