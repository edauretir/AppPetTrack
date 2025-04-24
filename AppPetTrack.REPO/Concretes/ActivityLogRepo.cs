using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class ActivityLogRepo : BaseRepo<ActivityLog>, IActivityLogRepo
    {
        public ActivityLogRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }

}
