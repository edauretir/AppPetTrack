using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class TrackerDeviceRepo : BaseRepo<TrackerDevice>, ITrackerDeviceRepo
    {
        public TrackerDeviceRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }

}
