using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IPetOwnerService
    {
        void Add(string userName,string password,string firstName, string lastName, string phoneNumber, string address, string email);
        void Update(int id, string firstName, string lastName, string phoneNumber, string address, string email);
        void Delete(int id);
        void SoftDelete(int id);
        bool CheckAccount(string userName,string password);
        PetOwner GetByUserName(string userName);
        PetOwner Get(int id);
        IEnumerable<PetOwner> GetAllTrack();
        IEnumerable<PetOwner> GetAllNoTrack();
        IEnumerable<PetOwner> GetByName(string name);
    }
}
