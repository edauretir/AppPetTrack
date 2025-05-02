using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IAlertService
    {
        void Add(int petId,double bodyTempature, TimeSpan inactivity, bool escape, double weight);
        void Update(int petId, double bodyTempature, TimeSpan inactivity, bool escape, double weight);
        void Delete(int id);
        void SoftDelete(int id);
        Alert Get(int id);
        IEnumerable<Alert> GetAllTrack();
        IEnumerable<Alert> GetAllNoTrack();
        
    }
}
