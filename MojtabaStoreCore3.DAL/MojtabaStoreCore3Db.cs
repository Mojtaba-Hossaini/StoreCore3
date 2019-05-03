using Microsoft.EntityFrameworkCore;
using MojtabaStoreCore3.Domain;
using System.Linq;

namespace MojtabaStoreCore3.DAL
{
    public class MojtabaStoreCore3Db : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MojtabaStoreCore3Db;Integrated Security=True");
        }
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries();

            foreach (var item in entities)
            {
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {

                    foreach (var f in item.Properties)
                    {
                        if (f.CurrentValue.ToString().Contains("ي"))
                        {

                            var newValue = f.CurrentValue.ToString().Replace('ي', 'ی');
                            f.CurrentValue = newValue;
                        }

                        if (f.CurrentValue.ToString().Contains("ك"))
                        {
                            var newValue = f.CurrentValue.ToString().Replace('ك', 'ک');
                            f.CurrentValue = newValue;
                        }
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
