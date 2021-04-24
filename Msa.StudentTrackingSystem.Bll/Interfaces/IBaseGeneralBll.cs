using Msa.StudentTrackingSystem.Model.Entities.Base;

namespace Msa.StudentTrackingSystem.Bll.Interfaces
{
    public interface IBaseGeneralBll
    {
        bool Insert(BaseEntity entity);
        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
        string GenerateNewKod();
    }
}
