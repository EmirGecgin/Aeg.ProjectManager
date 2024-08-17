using System.Data.Entity;

namespace Aeg.ProjectManager.Models.DataContext
{
    public class AegDbContext:DbContext
    {
        public AegDbContext():base("ProjectManagerDB")
        {
        }
        public DbSet<Personel.Personel> Personels { get; set; }

        private DbSet<Project.Project> projects;
        public System.Data.Entity.DbSet<Aeg.ProjectManager.Models.Project.Project> Projects { get; set; }
    }
}