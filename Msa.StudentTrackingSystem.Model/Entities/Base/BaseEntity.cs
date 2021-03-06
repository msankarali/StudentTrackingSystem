using Msa.StudentTrackingSystem.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msa.StudentTrackingSystem.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Column(Order = 1), Required, StringLength(20)]
        public virtual string Kod { get; set; }
    }
}