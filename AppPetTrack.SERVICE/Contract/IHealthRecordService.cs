﻿using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Models;

namespace AppPetTrack.SERVICE.Concretes
{
    public interface IHealthRecordService
    {
        void Add(int petId,HealthType healtyType, string description, DateTime recordDate);
        void Update(int petId, HealthType healtyType, string description, DateTime recordDate);
        void Delete(int id);
        void SoftDelete(int id);
        HealthRecord Get(int id);
        IEnumerable<HealthRecord> GetAllTrack();
        IEnumerable<HealthRecord> GetAllNoTrack();
        IEnumerable<HealthRecord> GetByHealthType(HealthType healthType);
    }
}
