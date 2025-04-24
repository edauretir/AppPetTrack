using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IPetOwnerService
    {
        void Add(string firstName, string lastName, string phoneNumber, string address, string email);
        void Update(int id, string firstName, string lastName, string phoneNumber, string address, string email);
        void Delete(int id);
        void SoftDelete (int id);
        PetOwner Get(int id);
        IEnumerable<PetOwner> GetAllTrack();
        IEnumerable<PetOwner> GetAllNoTrack();
        IEnumerable<PetOwner> GetByName(string name);


    }
}
