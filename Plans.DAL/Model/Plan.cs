using System.ComponentModel.DataAnnotations.Schema;
using Plans.Domain.Model;

namespace Plans.DAL.Model
{
    public class Plan: Entity, IPlan
    {
        public string Name { get; set; }

        [Column("descr")]
        public string Description { get; set; }

        public int? Priority { get; set; }
    }
}
