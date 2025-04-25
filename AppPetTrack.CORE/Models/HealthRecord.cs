using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Enums;

namespace AppPetTrack.CORE.Models
{
    public class HealthRecord : BaseEntity
    {
        private HealthType _healthType;//aşı, alerji, hastalık, kontrol
        private string _description;//kuduz, polen, rutin kontrol
        private DateTime _recordDate;

        public HealthRecord() { }

        public HealthRecord(HealthType healthType, string description, DateTime recordDate)
        {
            HealthType = healthType;
            Description = description;
            RecordDate = recordDate;
        }

        public DateTime RecordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public HealthType HealthType
        {
            get { return _healthType; }
            set { _healthType = value; }
        }

        //Navigation Propertires
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; } //Bir sağlık kaydı bir hayvana ait olabilir.

        public override string ToString()
        {
            return $"Id: {Id} Kayıt Tarihi {RecordDate} - Sağlık Türü: {HealthType} - Açıklama: {Description}";
        }
    }
}
