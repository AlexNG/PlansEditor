using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Plans.DAL.Model;
using Plans.Domain.Service;

namespace Plans.DAL.Service
{
    public class ContextService : DbContext, IContextService
    {
        public ContextService(DbContextOptions<ContextService> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>();
            modelBuilder.Entity<Plan>();
            modelBuilder.Entity<PlanVM>();
        }
    }
}
