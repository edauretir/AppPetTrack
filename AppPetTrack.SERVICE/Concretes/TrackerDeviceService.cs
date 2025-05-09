﻿using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class TrackerDeviceService : ITrackerDeviceService
    {
        private readonly IManagerRepo _repo;

        public TrackerDeviceService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(int petId, DateTime loggedAt, string location)
        {
            if (string.IsNullOrEmpty(loggedAt.ToString()) || string.IsNullOrEmpty(location))
                throw new ValidationException("LoggetAt, Location", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.TrackerDevices.Create(new TrackerDevice(petId,loggedAt, location));

            if (!_repo.Save())
                throw new Exception("Tracker Device kayır edilemedi!");
        }

        public void Delete(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);

            if (trackerDevice is null)
                throw new NotFoundException("Tracker Device", id);

            _repo.TrackerDevices.Delete(trackerDevice, false);

            if (!_repo.Save())
                throw new Exception("Trackjer Device silinemedi!");
        }

        public TrackerDevice Get(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);

            if (trackerDevice is null)
                throw new NotFoundException("Tracker Device", id);

            return trackerDevice;
        }

        public IEnumerable<TrackerDevice> GetAllNoTrack() => _repo.TrackerDevices.GetAll(false);

        public IEnumerable<TrackerDevice> GetAllTrack() => _repo.TrackerDevices.GetAll();

        public IEnumerable<TrackerDevice> GetByDate(DateTime loggedAt) => _repo.TrackerDevices.GetByCondition(x => x.LoggedAt == loggedAt.Date).ToList();

        public void SoftDelete(int id)
        {
            var trackerDevice = _repo.TrackerDevices.GetById(id);

            if (trackerDevice is null)
                throw new NotFiniteNumberException("Tracker Device", id);

            _repo.TrackerDevices.Delete(trackerDevice);

            if (!_repo.Save())
                throw new Exception("Tracker device soft delete edilemedi!");
        }

        public void Update(int id, DateTime loggedAt, string location)
        {
            if (string.IsNullOrEmpty(loggedAt.ToString()) || string.IsNullOrEmpty(location))
                throw new ValidationException("LoggetAt, Location", "Verilen alanlardan biri boş veya geçersiz!");

            var trackerDevice = _repo.TrackerDevices.GetById(id);

            trackerDevice.LoggedAt = loggedAt;
            trackerDevice.Location = location;

            _repo.TrackerDevices.Update(trackerDevice);

            if(!_repo.Save())
                throw new Exception("Tracker Device güncellenemedi!");
        }
    }
}
