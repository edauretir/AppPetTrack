using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IVetAppointmentService
    {
        void Add(string clinicName, string veterinarianName, DateTime appointmentDate);
        void Update(int id, string clinicName, string veterinarianName, DateTime appointmentDate);
        void Delete(int id);
        void SoftDelete(int id);
        VetAppointment Get(int id);
        IEnumerable<VetAppointment> GetAllTrack();
        IEnumerable<VetAppointment> GetAllNoTrack();
        IEnumerable<VetAppointment> GetByClinicName(string clinicName);

    }
}
