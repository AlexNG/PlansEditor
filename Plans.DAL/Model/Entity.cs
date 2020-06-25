using System.ComponentModel.DataAnnotations;

namespace Plans.DAL.Model
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
