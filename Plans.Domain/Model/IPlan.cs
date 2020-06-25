namespace Plans.Domain.Model
{
    public interface IPlan : IEntity
    {
        string Name { get; set; }

        int? Priority { get; set; }

        string Description { get; set; }
    }
}
