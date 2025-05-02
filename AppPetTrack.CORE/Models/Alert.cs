using AppPetTrack.CORE.Abstracts;
using AppPetTrack.CORE.Helper;

namespace AppPetTrack.CORE.Models
{
    public class Alert : BaseEntity
    {
        private double _bodyTempature;
        private TimeSpan _inactivity;
        private bool _escape;
        private double _weight;

        public Alert() { }

        public Alert(int petId,double bodyTemature, TimeSpan inactivity, bool escape, double weight)
        {
            PetId = petId;
            BodyTempature = bodyTemature;
            Inactivity = inactivity;
            Escape = escape;
            Weight = weight;
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = ValidationHelper.ValidatePositiveDouble(value); }
        }
        public bool Escape
        {
            get { return _escape; }
            set { _escape = value; }
        }

        public TimeSpan Inactivity
        {
            get { return _inactivity; }
            set { _inactivity = value; }
        }

        public double BodyTempature
        {
            get { return _bodyTempature; }
            set { _bodyTempature = value; }
        }

        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }//Bir uyarı sadece 1 hayvana ait olabilir.

        public override string ToString()
        {
            return $"Id: {Id} - Vücut Isısı: {BodyTempature} - Hareketsizlik Süresi: {Inactivity} - Kaçtı Mı: {Escape} - Kilosu: {Weight}";
        }
    }
}
