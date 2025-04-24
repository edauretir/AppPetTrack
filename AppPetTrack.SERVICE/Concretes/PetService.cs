using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Helper;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetTrack.SERVICE.Concretes
{
    public class PetService : IPetService
    {
        private readonly IManagerRepo _repo;

        public PetService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(string name, PetSpecies species, string breed, DateTime birtDate, string vaccieInformation, double weight)
        {
            if (ValidationHelper.IsDefault(name) || ValidationHelper.IsDefault(species) || ValidationHelper.IsDefault(breed) || ValidationHelper.IsDefault(birtDate) || ValidationHelper.IsDefault(vaccieInformation) || ValidationHelper.IsDefault(weight)) 
            throw new ValidationException("Name, Species, Breed, BirthDate, VaccineInformation, Weight", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.Pets.Create(new Pet(name, species, breed, birtDate, vaccieInformation, weight));

        }

        public void Delete(int id)
        {
            var pet = _repo.Pets.GetById(id);

            if(pet is null)
                throw new NotFoundException("Pet", id);

            _repo.Pets.Delete(pet, false);

            if (!_repo.Save())
                throw new Exception("Pet silinemedi!");
        }

        public Pet Get(int id)
        {
            var pet = _repo.Pets.GetById(id);

            if (pet is null)
                throw new NotFoundException("Pet", id);

            return pet;
        }

        public IEnumerable<Pet> GetAllNoTrack() => _repo.Pets.GetAll(false);

        public IEnumerable<Pet> GetAllTrack() => _repo.Pets.GetAll();

        public IEnumerable<Pet> GetByName(string name) => _repo.Pets.GetByCondition(x => x.Name.Contains(name)).ToList();

        public void SoftDelete(int id)
        {
            var pet = _repo.Pets.GetById(id);

            if (pet is null)
                throw new NotFoundException("Pet", id);

            _repo.Pets.Delete(pet);
            if (!_repo.Save()) 
                throw new Exception("Pet soft delete edilemedi");
        }

        public void Update(int id, string name, PetSpecies species, string breed, DateTime birtDate, string vaccieInformation, double weight)
        {
            var pet = _repo.Pets.GetById(id);

            pet.Name = name;
            pet.Species = species;
            pet.Breed = breed;
            pet.BirthDate = birtDate;
            pet.VaccineInformation = vaccieInformation;
            pet.Weight = weight;

            _repo.Pets.Update(pet);

            if (!_repo.Save())
                throw new Exception("Pet güncellenemedi!");
        }
    }
}
