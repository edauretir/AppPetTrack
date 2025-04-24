using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;

namespace AppPetTrack.REPO.Concretes
{
    public class VetAppointmentRepo : BaseRepo<VetAppointment>, IVetAppointmentRepo
    {
        public VetAppointmentRepo(AppPetTrackDbContext context) : base(context)
        {
        }
    }

}
