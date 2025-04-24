using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class PetOwnerRepo : BaseRepo<PetOwner>, IPetOwnerRepo
    {
        public PetOwnerRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }
}
