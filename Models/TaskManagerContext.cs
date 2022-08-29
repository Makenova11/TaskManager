namespace TaskManager.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Контекст данных.
    /// </summary>
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }
        public DbSet<TaskModel> Tasks { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;
    }
}
