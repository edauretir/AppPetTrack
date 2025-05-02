using AppPetTrack.CORE.Models;

namespace AppPetTrack.REPO.Contract
{
    public interface IAlertRepo : IBaseRepo<Alert>
    {
        Task<bool> MarkEscapeAsync(int petId, bool escapeStatus);
    }
}
