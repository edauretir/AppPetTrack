using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IAlertService
    {
        void Add(double bodyTempature, TimeSpan inactivity, string escape, double weight);
        void Update(int id, double bodyTempature, TimeSpan inactivity, string escape, double weight);
        void Delete(int id);
        void SoftDelete(int id);
        Alert Get(int id);
        IEnumerable<Alert> GetAllTrack();
        IEnumerable<Alert> GetAllNoTrack();
        
    }
}
