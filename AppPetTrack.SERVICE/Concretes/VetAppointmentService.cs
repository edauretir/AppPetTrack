using AppPetTrack.CORE.Helper;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class VetAppointmentService : IVetAppointmentService
    {
        private readonly IManagerRepo _repo;

        public VetAppointmentService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(int petId, string clinicName, string veterinarianName, DateTime appointmentDate)
        {
            if (string.IsNullOrEmpty(petId.ToString())||string.IsNullOrEmpty(clinicName) || string.IsNullOrEmpty(veterinarianName) || string.IsNullOrEmpty(appointmentDate.ToString()))
                throw new ValidationException("PetId,Clinic Name, Veterininan Name, Appointment Date", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.VetAppointments.Create(new VetAppointment(petId,clinicName, veterinarianName, appointmentDate));

            if (!_repo.Save())
                throw new Exception("Vet Appointment kayıt edilemedi!");
        }

        public void Delete(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);

            if (vetAppointment is null)
                throw new NotFoundException("Vet Appointment", id);

            _repo.VetAppointments.Delete(vetAppointment, false);

            if (!_repo.Save())
                throw new Exception("Vet Appointment silinemedi!");
        }

        public VetAppointment Get(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);

            if (vetAppointment is null)
                throw new NotFoundException("Vet Appointment", id);

            return vetAppointment;
        }

        public IEnumerable<VetAppointment> GetAllNoTrack() => _repo.VetAppointments.GetAll(false);

        public IEnumerable<VetAppointment> GetAllTrack() => _repo.VetAppointments.GetAll();

        public IEnumerable<VetAppointment> GetByClinicName(string clinicName) => _repo.VetAppointments.GetByCondition(x => x.ClinicName.Contains(clinicName)).ToList();

        public void SoftDelete(int id)
        {
            var vetAppointment = _repo.VetAppointments.GetById(id);

            if (vetAppointment is null)
                throw new NotFoundException("Vet Appointment", id);

            _repo.VetAppointments.Delete(vetAppointment);

            if (!_repo.Save())
                throw new Exception("Vet Appointment soft delete edilemedi!");
        }

        public void Update(int id,int petId, string clinicName, string veterinarianName, DateTime appointmentDate)
        {
            if (string.IsNullOrEmpty(clinicName) || string.IsNullOrEmpty(veterinarianName) || string.IsNullOrEmpty(appointmentDate.ToString()))
                throw new ValidationException("Clinic Name, Veterininan Name, Appointment Date", "Verilen alanlardan biri boş veya geçersiz!");

            var vetAppointment = _repo.VetAppointments.GetById(id);

            vetAppointment.ClinicName = clinicName;
            vetAppointment.VeterinarianName = veterinarianName;
            vetAppointment.AppointmentDate = appointmentDate;

            _repo.VetAppointments.Update(vetAppointment);

            if (!_repo.Save())
                throw new Exception("Vet Appointment güncellenemedi!");
        }
    }
}
