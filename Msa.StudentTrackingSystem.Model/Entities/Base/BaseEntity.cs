using Msa.StudentTrackingSystem.Model.Entities.Base.Interfaces;

namespace Msa.StudentTrackingSystem.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public string Kod { get; set; }
    }
}
