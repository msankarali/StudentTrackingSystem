using Msa.StudentTrackingSystem.Data.StudentTrackingSystemMigration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Msa.StudentTrackingSystem.Data.Contexts
{
    public class StudentTrackingSystemContext : BaseDbContext<StudentTrackingSystemContext, Configuration>
    {
        public StudentTrackingSystemContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public StudentTrackingSystemContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}