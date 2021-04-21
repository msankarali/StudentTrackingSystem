using Msa.StudentTrackingSystem.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
