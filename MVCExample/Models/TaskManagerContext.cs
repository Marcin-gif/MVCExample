using Microsoft.EntityFrameworkCore;

namespace MVCExample.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().HasKey(t=>t.TaskId);
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.TaskId)
                .ValueGeneratedOnAdd();
        }
    }
}
