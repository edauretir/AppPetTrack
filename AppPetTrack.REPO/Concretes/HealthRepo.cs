using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class HealthRepo : BaseRepo<HealthRecord>, IHealthRecordRepo
    {
        public HealthRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }

}
