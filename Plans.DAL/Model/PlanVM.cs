using System.ComponentModel.DataAnnotations.Schema;
using Plans.Domain.Model;

namespace Plans.DAL.Model
{
    [Table("plan_vm")]
    public class PlanVM : Entity, IPlan
    {
        public string Name { get; set; }

        [Column("descr")]
        public string Description { get; set; }

        public int? Priority { get; set; }

        [Column("event_count")]
        public int EventCount { get; set; }
    }
}
