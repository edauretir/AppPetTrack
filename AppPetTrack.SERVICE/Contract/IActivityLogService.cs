using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IActivityLogService
    {
        void Add(int trackerId,DateTime activityDate, TimeSpan dailyWalkTime, TimeSpan dailyRunTime, TimeSpan dailySleepTime);
        void Update(int id, DateTime activityDate, TimeSpan dailyWalkTime, TimeSpan dailyRunTime, TimeSpan dailySleepTime);
        void Delete(int id);
        void SoftDelete(int id);
        ActivityLog Get(int id);
        IEnumerable<ActivityLog> GetAllTrack();
        IEnumerable<ActivityLog> GetAllNoTrack();
        IEnumerable<ActivityLog> GetByDate(DateTime activityDate);
    }
}
