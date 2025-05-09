﻿using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Helper;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Concretes
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IManagerRepo _repo;

        public HealthRecordService(IManagerRepo repo)
        {
            _repo = repo;
        }

        public void Add(int petId, HealthType healtyType, string description, DateTime recordDate)
        {
            if (string.IsNullOrEmpty(healtyType.ToString()) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(recordDate.ToString()))
                throw new ValidationException("HealthType, Description, RecordDate", "Verilen alanlardan biri boş veya geçersiz!");

            _repo.HealthRecords.Create(new HealthRecord(petId, healtyType, description, recordDate));

            if (!_repo.Save())
                throw new Exception("Health Record kayıt edilemedi.");
        }

        public void Delete(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("HealthRecord", id);

            _repo.HealthRecords.Delete(healthRecord, false);

            if (!_repo.Save())
                throw new Exception("Health Record silinemedi.");
        }

        public HealthRecord Get(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);

            if (healthRecord is null)
                throw new NotFoundException("HeathRecod", id);

            return healthRecord;
        }

        public IEnumerable<HealthRecord> GetAllNoTrack() => _repo.HealthRecords.GetAll(false);
        public IEnumerable<HealthRecord> GetAllTrack() => _repo.HealthRecords.GetAll();
        public IEnumerable<HealthRecord> GetByHealthType(HealthType healthType) => _repo.HealthRecords.GetByCondition(x => x.HealthType == healthType).ToList();

        public void SoftDelete(int id)
        {
            var healthRecord = _repo.HealthRecords.GetById(id);
            if (healthRecord is null)
                throw new NotFoundException("Health Record", id);

            _repo.HealthRecords.Delete(healthRecord);

            if (!_repo.Save())
                throw new Exception("Health Record soft delete edilemedi!");
        }

        public void Update(int id, HealthType healtyType, string description, DateTime recordDate)
        {
            if (string.IsNullOrEmpty(healtyType.ToString()) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(recordDate.ToString()))
                throw new ValidationException("HealthType, Description, RecordDate", "Verilen alanlardan biri boş veya geçersiz!");

            var healthRecord = _repo.HealthRecords.GetById(id);

            healthRecord.HealthType = healtyType;
            healthRecord.Description = description;
            healthRecord.RecordDate = recordDate;

            _repo.HealthRecords.Update(healthRecord);

            if (!_repo.Save())
                throw new Exception("Health Record güncellenemedi!");

        }
    }
}
