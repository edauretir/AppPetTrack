using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly IManagerRepo _repo;

        public PetOwnerService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(string userName,string password,string firstName, string lastName, string phoneNumber, string address, string email)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email))
                throw new ValidationException("FirstName, LastName, PhoneNumber, Address, Email", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.PetOwners.Create(new PetOwner(userName, password, firstName, lastName, phoneNumber, address, email));

            if (!_repo.Save())
                throw new Exception("Pet Owner kayıt edilemedi.");
        }

        public bool CheckAccount(string userName, string password)
        {
            var petOwner = _repo.PetOwners.GetByCondition(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            int id = petOwner.Id;
            if (petOwner is null)
                throw new NotFoundException("Pet Owner", id);
            return true;
        }

        public void Delete(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("Pet Owner", id);

            _repo.PetOwners.Delete(petOwner, false);

            if (!_repo.Save())
                throw new Exception("Pet Owner silinemedi!");
        }

        public PetOwner Get(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("Pet Owner", id);
            return petOwner;
        }

        public IEnumerable<PetOwner> GetAllNoTrack() => _repo.PetOwners.GetAll(false);

        public IEnumerable<PetOwner> GetAllTrack() => _repo.PetOwners.GetAll();

        public IEnumerable<PetOwner> GetByName(string name) => _repo.PetOwners.GetByCondition(x => x.FirstName.Contains(name)).ToList();

        public PetOwner GetByUserName(string userName)
        {
            var petOwner = _repo.PetOwners.GetByCondition(x => x.UserName == userName).FirstOrDefault();
            int id = petOwner.Id;
            if (petOwner is null)
                throw new NotFoundException("Pet Owner", id);
            return petOwner;
        }

        public void SoftDelete(int id)
        {
            var petOwner = _repo.PetOwners.GetById(id);
            if (petOwner is null)
                throw new NotFoundException("Pet Owner", id);

            _repo.PetOwners.Delete(petOwner);

            if (!_repo.Save())
                throw new Exception("Pet Owner sof delete edilemedi!");
        }

        public void Update(int id, string firstName, string lastName, string phoneNumber, string address, string email)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email))
                throw new ValidationException("FirstName, LastName, PhoneNumber, Address, Email", "Verilen alanlardan biri boş veya geçersiz!");

            var petOwner = _repo.PetOwners.GetById(id);

            petOwner.FirstName = firstName;
            petOwner.LastName = lastName;
            petOwner.PhoneNumber = phoneNumber;
            petOwner.Address = address;
            petOwner.Email = email;

            _repo.PetOwners.Update(petOwner);

            if (!_repo.Save())
                throw new Exception("Pet Owner güncellenemedi");
        }
    }
}
