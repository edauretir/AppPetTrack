using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPetTrack.REPO.Configs
{
    public class AlertConfig : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            throw new NotImplementedException();
        }
    }

}
