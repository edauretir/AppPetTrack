using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class ActivityLogService : IActivityLogService
    {

        private readonly IManagerRepo _repo;

        public ActivityLogService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(DateTime activityDate, TimeSpan dailyWalkTime, TimeSpan dailyRunTime, TimeSpan dailySleepTime)
        {
            if(string.IsNullOrEmpty(activityDate.ToString()) || string.IsNullOrEmpty(dailyWalkTime.ToString()) || string.IsNullOrEmpty(dailyRunTime.ToString()) || string.IsNullOrEmpty(dailySleepTime.ToString()))
                throw new ValidationException("ActivityDate, DailyWalkTime, DailyRunTime, DailySleepTime", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.ActivityLogs.Create(new ActivityLog(activityDate, dailyWalkTime, dailyRunTime, dailySleepTime));

            if (!_repo.Save())
                throw new Exception("Activity Log kayıt edilemedi!");
        }

        public void Delete(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);

            if (activityLog is null) 
                throw new NotFoundException("ActivityLog", id);

            _repo.ActivityLogs.Delete(activityLog, false);

            if (!_repo.Save())
                throw new Exception("Activity Log silinemedi!");
        }

        public ActivityLog Get(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);

            if (activityLog is null)
                throw new NotFoundException("ActivityLog", id);

            return activityLog;
        }

        public IEnumerable<ActivityLog> GetAllNoTrack() => _repo.ActivityLogs.GetAll(false);
    
        public IEnumerable<ActivityLog> GetAllTrack() => _repo.ActivityLogs.GetAll();

        public IEnumerable<ActivityLog> GetByDate(DateTime activityDate) => _repo.ActivityLogs.GetByCondition(x => x.ActivityDate == activityDate.Date).ToList();

        public void SoftDelete(int id)
        {
            var activityLog = _repo.ActivityLogs.GetById(id);
            if (activityLog is null)
                throw new NotFoundException("ActivityLog", id);
            
            _repo.ActivityLogs.Delete(activityLog);

            if (!_repo.Save())
                throw new Exception("Activity Log soft delete edilemedi!");
        } 

        public void Update(int id, DateTime activityDate, TimeSpan dailyWalkTime, TimeSpan dailyRunTime, TimeSpan dailySleepTime)
        {
            if (string.IsNullOrEmpty(activityDate.ToString()) || string.IsNullOrEmpty(dailyWalkTime.ToString()) || string.IsNullOrEmpty(dailyRunTime.ToString()) || string.IsNullOrEmpty(dailySleepTime.ToString()))
                throw new ValidationException("ActivityDate, DailyWalkTime, DailyRunTime, DailySleepTime", "Verilen alanlardan biri boş veya geçersiz!");

            var activityLog = _repo.ActivityLogs.GetById(id);

            activityLog.ActivityDate = activityDate;
            activityLog.DailyWalkTime = dailyWalkTime;
            activityLog.DailyRunTime = dailyRunTime;
            activityLog.DailySleepTime = dailySleepTime;

            _repo.ActivityLogs.Update(activityLog);

            if (!_repo.Save())
                throw new Exception("Activity Log güncellenemedi!");
        }
    }
}
