using Msa.StudentTrackingSystem.Data.Contexts;
using System.Data.Entity.Migrations;

namespace Msa.StudentTrackingSystem.Data.StudentTrackingSystemMigration
{
    public class Configuration : DbMigrationsConfiguration<StudentTrackingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}