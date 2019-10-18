using Microsoft.EntityFrameworkCore;
using studentsCRUD.StudentsModel;

namespace studentsCRUD.AppDBContext {
    public class DBContext : DbContext {

        public DbSet<Student> Students {get; set;}
        public DbSet<StudentInfo> StudentInfos {get; set;}

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Making Unique Keys 
            //modelBuilder.Entity<Student>().HasIndex(u => u.StudentID).IsUnique();
            //modelBuilder.Entity<Student>().HasIndex(u => u.Email).IsUnique();
        }
    }
}