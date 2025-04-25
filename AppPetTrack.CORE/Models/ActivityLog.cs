using AppPetTrack.CORE.Abstracts;

namespace AppPetTrack.CORE.Models
{
    public class ActivityLog : BaseEntity
    {
		private DateTime _activityDate;
		private TimeSpan _dailyWalkTime;
		private TimeSpan _dailyRunTime;
        private TimeSpan _dailySleepTime;

        public ActivityLog() { }

        public ActivityLog(DateTime activityDate, TimeSpan dailyWalkTime, TimeSpan dailyRunTime, TimeSpan dailySleepTime)
        {
            ActivityDate = activityDate;
            DailyWalkTime = dailyWalkTime;
            DailyRunTime = dailyRunTime;
            DailySleepTime = dailySleepTime;
        }

        public TimeSpan DailySleepTime
		{
			get { return _dailySleepTime; }
			set { _dailySleepTime = value; }
		}

		public TimeSpan DailyRunTime
		{
			get { return _dailyRunTime; }
			set { _dailyRunTime = value; }
		}

        public TimeSpan DailyWalkTime
		{
			get { return _dailyWalkTime; }
			set { _dailyWalkTime = value; }
		}
        public DateTime ActivityDate
        {
            get { return _activityDate; }
            set { _activityDate = value; }
        }

        //Navigation Properties
        public int TrackerDeviceId { get; set; }
        public TrackerDevice TrackerDevice { get; set; } //Bir aktivite kaydı bir takip cihazına bağlı olabilir.

        public override string ToString()
        {
            return $"Id {Id} - Aktivite Tarihi: {ActivityDate} - Günlük Yürüyüş Süresi: {DailyWalkTime}  - Günlük Koşu Süresi: {DailyRunTime} - Günlük Uyku Süresi: {DailySleepTime}";
        }
    }
}
