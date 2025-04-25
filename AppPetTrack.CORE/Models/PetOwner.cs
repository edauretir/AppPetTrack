using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Helper;

namespace AppPetTrack.CORE.Models
{
    public class PetOwner : BaseEntity
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _address;
        private string _email;

        public PetOwner() { }

        public PetOwner(string firstName, string lastName, string phoneNumber, string address, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
        }

        public string Email
        {
            get { return _email; }
            set { _email = ValidationHelper.SetData(value); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = ValidationHelper.SetData(value); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.Length != 11)
                    throw new Exception("Telefon numarası 11 haneli olmalıdır!!!");
                if (value.All(char.IsDigit))
                    throw new Exception("Telefon numarası rakamlardan oluşmalıdır.");
                _phoneNumber = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = ValidationHelper.SetData(value); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = ValidationHelper.SetData(value); }
        }

        //Navigation Properties
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public override string ToString()
        {
            return $"Id: {Id} - Ad: {FirstName} - Soyad: {LastName} - Telefon Numarası: {PhoneNumber} - Adres: {Address} -Email: {Email}";
        }
    }
}
