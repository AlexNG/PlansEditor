using System;
using System.ComponentModel.DataAnnotations.Schema;
using Plans.Domain.Model;

namespace Plans.DAL.Model
{
    public class Event: Entity, IEvent
    {
        [Column("plan_id")]
        public long PlanId { get; set; }

        public DateTime Date { get; set; }

        [Column("descr")]
        public string Description { get; set; }
    }
}
