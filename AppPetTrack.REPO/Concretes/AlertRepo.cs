using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.Contract;
using Microsoft.EntityFrameworkCore;

namespace AppPetTrack.REPO.Concretes
{
    public class AlertRepo : BaseRepo<Alert>, IAlertRepo
    {
        private readonly AppPetTrackDbContext _context;

        public AlertRepo(AppPetTrackDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> MarkEscapeAsync(int petId, bool escapeStatus)
        {
            var pet = await _context.Pets
                                     .Include(p => p.Alert)
                                     .FirstOrDefaultAsync(p => p.Id == petId);

            if (pet == null)
                return false;

            if (pet.Alert == null)
            {
                pet.Alert = new Alert
                {
                    PetId = petId,
                    Escape = escapeStatus,
                    BodyTempature = 0,
                    Inactivity = TimeSpan.Zero,
                    Weight = 0
                };
                await _context.Alerts.AddAsync(pet.Alert);
            }
            else
            {
                pet.Alert.Escape = escapeStatus;
            }

            await _context.SaveChangesAsync();
            return true;
        }


    }
}
