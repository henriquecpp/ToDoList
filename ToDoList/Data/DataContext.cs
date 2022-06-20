using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            var user = mb.Entity<ToDo>();
            user.ToTable("ToDo");
            user.HasKey(x => x.ID);
            user.Property(x => x.ID).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Title).HasColumnName("title").IsRequired();
            user.Property(x => x.Desc).HasColumnName("desc").IsRequired();
            user.Property(x => x.PlannedDate).HasColumnName("planned_date").IsRequired();
            user.Property(x => x.DateAdded).HasColumnName("date_added").IsRequired();
        }

    }
}
