using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.UnitOfWork
{
    public interface IManagerRepo
    {
        IPetOwnerRepo PetOwners { get; }
        IPetRepo Pets {  get; }
        ITrackerDeviceRepo TrackerDevices { get; }
        IVetAppointmentRepo VetAppointments { get; }
        IHealthRecordRepo HealthRecords { get; }
        IAlertRepo Alerts { get; }
        IActivityLogRepo ActivityLogs { get; }
        bool Save();

    }
}
