using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IPetService
    {
        void Add(string name, PetSpecies species, string breed, DateTime birtDate, string vaccieInformation, double weight );
        void Update(int id, string name, PetSpecies species, string breed, DateTime birtDate, string vaccieInformation, double weight);
        void Delete(int id);
        void SoftDelete(int id);
        Pet Get(int id);
        IEnumerable<Pet> GetAllTrack();
        IEnumerable<Pet> GetAllNoTrack();
        IEnumerable<Pet> GetByName(string name);
    }
}
