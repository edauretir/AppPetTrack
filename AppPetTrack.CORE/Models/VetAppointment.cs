using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Helper;

namespace AppPetTrack.CORE.Models
{
    public class VetAppointment : BaseEntity
    {
        private string _clinicName;
        private string _veterinarianName;
        private DateTime _appointmentDate;
        public VetAppointment() { }

        public VetAppointment(string clinicName, string veterinarianName, DateTime appointmentDate)
        {
            ClinicName = clinicName;
            VeterinarianName = veterinarianName;
            AppointmentDate = appointmentDate;
        }

        public DateTime AppointmentDate
        {
            get { return _appointmentDate; }
            set
            {
                if (value < DateTime.UtcNow)
                    throw new ArgumentOutOfRangeException($"Randevu tarihi ({value}) şu andan ({DateTime.UtcNow}) önce olamaz.");
                _appointmentDate = value;
            }
        }

        public string VeterinarianName
        {
            get { return _veterinarianName; }
            set { _veterinarianName = ValidationHelper.SetData(value); }
        }

        public string ClinicName
        {
            get { return _clinicName; }
            set { _clinicName = ValidationHelper.SetData(value); }
        }

        //Navigation Properties
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Klinik Adı: {ClinicName} - Veteriner Adı:{VeterinarianName} - Randevu Tarihi: {AppointmentDate}";
        }
    }
}
