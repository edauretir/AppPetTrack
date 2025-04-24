using AppPetTrack.CORE.Abstracts;
using System.Linq.Expressions;

namespace AppPetTrack.REPO.Contract
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool track = true); // Bütün datayı getirir.
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition); //Linq sorgularına göre getirme işlemi yapar.
        T? GetById(int id); //İd ye göre data getirir.
        void Create(T entity); //Veri ekleme
        void Update(T entity); //Veri Güncellme
        void Delete(T entity, bool softDelete = true); //Veri silme işlemi yapar. - softdelete silindi olarak işaretler ama silmez.
    }
}
