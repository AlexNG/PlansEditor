using System;

namespace Plans.Domain.Model
{
    public interface IEvent : IEntity
    {
        long PlanId { get; set; }

        DateTime Date { get; set; }

        string Description { get; set; }
    }
}
