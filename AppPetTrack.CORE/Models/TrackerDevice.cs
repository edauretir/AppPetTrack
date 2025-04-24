using AppPetTrack.CORE.Abstracts;

namespace AppPetTrack.CORE.Models
{
    public class TrackerDevice : BaseEntity
    {
        private DateTime _loggedAt;
        private string _location;

        public TrackerDevice() { }

        public TrackerDevice(DateTime loggedAt, string location)
        {
            _loggedAt = loggedAt;
            _location = location;
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public DateTime LoggedAt
        {
            get { return _loggedAt; }
            set { _loggedAt = value; }
        }

        //Navigation Properties
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }

    }
}
