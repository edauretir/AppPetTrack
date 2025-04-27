using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Helper;

namespace AppPetTrack.CORE.Models
{
    public class Pet : BaseEntity
    {
        private string _name;
        private PetSpecies _species;
        private string _breed;
        private DateTime _birthDate;
        private string _vaccineInformation;
        private double _weight;

        public Pet() { }

        public Pet(int petOwnerId,string name, PetSpecies species, string breed, DateTime birthDate, string vaccineInformation, double weight)
        {
            Name = name;
            Species = species;
            Breed = breed;
            BirthDate = birthDate;
            VaccineInformation = vaccineInformation;
            Weight = weight;
            PetOwnerId = petOwnerId;
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = ValidationHelper.ValidatePositiveDouble(value);
            }
        }

        public string VaccineInformation
        {
            get { return _vaccineInformation; }
            set { _vaccineInformation = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Breed
        {
            get { return _breed; }
            set { _breed = ValidationHelper.SetData(value); }
        }

        public PetSpecies Species
        {
            get { return _species; }
            set { _species = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = ValidationHelper.SetData(value); }
        }

        public Guid MicrochipNumber { get; private set; } = Guid.NewGuid();

        //Navigation Properties
        public int PetOwnerId { get; set; }
        public int TrackerDeviceId { get; set; }
        public int AlertId { get; set; }
        public virtual Alert Alert { get; set; }//Bir hayvanın bir uyarısı olabilir.
        public virtual PetOwner PetOwner { get; set; } //Bir hayvanın bir sahibi olabilir.
        public virtual TrackerDevice TrackerDevice { get; set; }//Bir hayvanın bir takip cihazı olabilir.
        public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();//Bir hayvanın birden fazla sahibi olabilir.
        public virtual ICollection<VetAppointment> VetAppointment { get; set; } = new List<VetAppointment>();//Birden fazla veteriner ziyareti

        public override string ToString()
        {
            return $"Id: {Id} - İsmi: {Name} - Türü: {Species} - Cinsi: {Breed} - Doğum Tarihi: {BirthDate} - Kilosu: {Weight} - Aşı Bilgisi: {VaccineInformation}";
        }
    }
}
