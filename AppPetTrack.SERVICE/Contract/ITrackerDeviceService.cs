using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface ITrackerDeviceService
    {
        void Add(int petId,DateTime loggedAt, string location);
        void Update(int id, DateTime loggedAt, string location);
        void Delete(int id);
        void SoftDelete(int id);
        TrackerDevice Get(int id);
        IEnumerable<TrackerDevice> GetAllTrack();
        IEnumerable<TrackerDevice> GetAllNoTrack();
        IEnumerable<TrackerDevice> GetByDate(DateTime loggedAt);
    }
}
