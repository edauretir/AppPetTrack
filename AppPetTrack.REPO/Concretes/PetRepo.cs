using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class PetRepo : BaseRepo<Pet>, IPetRepo
    {
        public PetRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }

}
