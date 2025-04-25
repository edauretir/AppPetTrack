using AppPetTrack.REPO.Concretes;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.UnitOfWork
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly AppPetTrackDbContext _context;
        private readonly Lazy<IActivityLogRepo> _activityLogRepo;
        private readonly Lazy<IAlertRepo> _alertRepo;
        private readonly Lazy<IHealthRecordRepo> _healthRecordRepo;
        private readonly Lazy<IPetOwnerRepo> _petOwnerRepo;
        private readonly Lazy<IPetRepo> _petRepo;
        private readonly Lazy<ITrackerDeviceRepo> _trackerRepo;
        private readonly Lazy<IVetAppointmentRepo> _vetAppointmentRepo;

        public ManagerRepo(AppPetTrackDbContext context)
        {
            _context = context;
            _activityLogRepo = new Lazy<IActivityLogRepo>(() => new ActivityLogRepo(_context));
            _alertRepo = new Lazy<IAlertRepo>(() => new AlertRepo(_context));
            _healthRecordRepo = new Lazy<IHealthRecordRepo>(() => new HealthRepo(_context));
            _petOwnerRepo = new Lazy<IPetOwnerRepo>(() => new PetOwnerRepo(_context));
            _petRepo = new Lazy<IPetRepo>(() => new PetRepo(_context));
            _trackerRepo = new Lazy<ITrackerDeviceRepo>(() => new TrackerDeviceRepo(_context));
            _vetAppointmentRepo = new Lazy<IVetAppointmentRepo>(() => new VetAppointmentRepo(_context));
        }

        public IActivityLogRepo ActivityLogs => _activityLogRepo.Value;
        public IAlertRepo Alerts => _alertRepo.Value;
        public IHealthRecordRepo HealthRecords => _healthRecordRepo.Value;
        public IPetOwnerRepo PetOwners => _petOwnerRepo.Value;
        public IPetRepo Pets => _petRepo.Value;
        public ITrackerDeviceRepo TrackerDevicers => _trackerRepo.Value;
        public IVetAppointmentRepo VetAppointments => _vetAppointmentRepo.Value;

        public ITrackerDeviceRepo TrackerDevices => throw new NotImplementedException();

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }

}
