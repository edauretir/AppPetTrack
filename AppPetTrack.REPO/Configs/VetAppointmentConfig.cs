using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPetTrack.REPO.Configs
{
    public class VetAppointmentConfig : IEntityTypeConfiguration<VetAppointment>
    {
        public void Configure(EntityTypeBuilder<VetAppointment> builder)
        {
            throw new NotImplementedException();
        }
    }

}
