using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Concretes;
using AppPetTrack.SERVICE.Exceptions;

namespace AppPetTrack.SERVICE.Contracts
{
    public class AlertService : IAlertService
    {
        private readonly IManagerRepo _repo;

        public AlertService(IManagerRepo repo)
        {
            _repo = repo;
        }
        public void Add(double bodyTempature, TimeSpan inactivity, string escape, double weight)
        {
            if (string.IsNullOrEmpty(bodyTempature.ToString()) || string.IsNullOrEmpty(inactivity.ToString()) || string.IsNullOrEmpty(escape) || string.IsNullOrEmpty(weight.ToString()))
                throw new ValidationException("BodyTempature, Inactivity , Escape, Weight", "Verilen alanlardan biri boş veya geçersiz!");

                _repo.Alerts.Create(new Alert { BodyTempature = bodyTempature, Inactivity = inactivity, Escape = escape, Weight = weight });

            if (!_repo.Save())
                throw new Exception("Alert kayıt edilemedi!");
        }

        public void Delete(int id)
        {
            var alert = _repo.Alerts.GetById(id);
            if (alert is null)
                throw new NotFoundException("Alert", id);

            _repo.Alerts.Delete(alert, false);

            if (!_repo.Save())
                throw new Exception("Alert silinemedi!");
        }

        public Alert Get(int id)
        {
            var alert = _repo.Alerts.GetById(id);
            if (alert is null)
                throw new NotFoundException("alert", id);

            return alert;
        }

        public IEnumerable<Alert> GetAllNoTrack() => _repo.Alerts.GetAll(false);

        public IEnumerable<Alert> GetAllTrack() => _repo.Alerts.GetAll();

        public void SoftDelete(int id)
        {
            var alert = _repo.Alerts.GetById(id);
            if (alert is null)
                throw new NotFoundException("Alert", id);
            _repo.Alerts.Delete(alert);

            if (!_repo.Save())
                throw new Exception("Alert soft delete edilemedi");
        }

        public void Update(int id, double bodyTempature, TimeSpan inactivity, string escape, double weight)
        {
            if (string.IsNullOrEmpty(bodyTempature.ToString()) || string.IsNullOrEmpty(inactivity.ToString()) || string.IsNullOrEmpty(escape) || string.IsNullOrEmpty(weight.ToString()))
                throw new ValidationException("BodyTempature, Inactivity , Escape, Weight", "Verilen alanlardan biri boş veya geçersiz!");

            var alert = _repo.Alerts.GetById(id);

            alert.BodyTempature = bodyTempature;
            alert.Inactivity = inactivity;
            alert.Escape = escape;
            alert.Weight = weight;

            _repo.Alerts.Update(alert);

            if (!_repo.Save())
                throw new Exception("Alert güncellenemedi!");
        }
    }
}
