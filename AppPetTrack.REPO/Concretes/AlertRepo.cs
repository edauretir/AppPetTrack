using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class AlertRepo : BaseRepo<Alert>, IAlertRepo
    {
        public AlertRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }
}
