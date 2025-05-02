using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class PetService : IPetService
    {
        private readonly IManagerRepo _repo;

        public PetService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(int petOwnerId,string name, PetSpecies species, string breed, DateTime birthDate, string vaccieInformation, double weight)
        {
            if (string.IsNullOrEmpty(petOwnerId.ToString())||string.IsNullOrEmpty(name) || string.IsNullOrEmpty(species.ToString()) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(birthDate.ToString()) || string.IsNullOrEmpty(vaccieInformation) || string.IsNullOrEmpty(weight.ToString()))
                throw new ValidationException("Name, Species, Breed, BirthDate, VaccineInformation, Weight", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.Pets.Create(new Pet(petOwnerId,name, species, breed, birthDate, vaccieInformation, weight));
            if (!_repo.Save())
                throw new Exception("Pet eklenemedi!");
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

        public void Update(int id, string name, PetSpecies species, string breed, DateTime birthDate, string vaccieInformation, double weight)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(species.ToString()) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(birthDate.ToString()) || string.IsNullOrEmpty(vaccieInformation) || string.IsNullOrEmpty(weight.ToString()))
                throw new ValidationException("Name, Species, Breed, BirthDate, VaccineInformation, Weight", "Verilen alanlardan biri boş veya geçersiz!");

            var pet = _repo.Pets.GetById(id);

            pet.Name = name;
            pet.Species = species;
            pet.Breed = breed;
            pet.BirthDate = birthDate;
            pet.VaccineInformation = vaccieInformation;
            pet.Weight = weight;

            _repo.Pets.Update(pet);

            if (!_repo.Save())
                throw new Exception("Pet güncellenemedi!");
        }















        //private readonly IAlertRepo _alertRepo;
        //private readonly IGeolocationService _geolocationService;

        //public PetService(IAlertRepo alertRepository, IGeolocationService geolocationService)
        //{
        //    _alertRepo = alertRepository;
        //    _geolocationService = geolocationService;
        //}

        //public async Task CheckEscapeStatusAsync(string ownerAddress, string petAddress, int petId)
        //{
        //    var ownerCoordinates = await _geolocationService.GetCoordinatesFromAddress(ownerAddress);
        //    var petCoordinates = await _geolocationService.GetCoordinatesFromAddress(petAddress);

        //    if (ownerCoordinates == null || petCoordinates == null)
        //    {
        //        Console.WriteLine("Adreslerden biri bulunamadı.");
        //        return;
        //    }

        //    // Mesafe hesaplama
        //    double distance = HaversineDistance(ownerCoordinates.Value.lat, ownerCoordinates.Value.lon,
        //                                        petCoordinates.Value.lat, petCoordinates.Value.lon);

        //    Console.WriteLine($"\nMesafe: {distance} metre");

        //    if (distance > 500)
        //    {
        //        Console.WriteLine("Evcil hayvanınız kaçmış olabilir!");
        //        await _alertRepo.MarkEscapeAsync(petId, "Kaçtı");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Evcil hayvanınız yakın.");
        //        await _alertRepo.MarkEscapeAsync(petId, "Kaçmadı");
        //    }
        //}

        //// Haversine hesaplaması - mesafeyi metre cinsinden hesaplıyor
        //private double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        //{
        //    const double R = 6371; // dünyanın yarı çapı km
        //    double dLat = (lat2 - lat1) * Math.PI / 180;
        //    double dLon = (lon2 - lon1) * Math.PI / 180;

        //    double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        //               Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
        //               Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        //    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        //    return R * c * 1000; // km'den metreye dönüştür
        //}
    }
}
