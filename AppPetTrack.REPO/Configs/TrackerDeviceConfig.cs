using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPetTrack.REPO.Configs
{
    public class TrackerDeviceConfig : IEntityTypeConfiguration<TrackerDevice>
    {
        public void Configure(EntityTypeBuilder<TrackerDevice> builder)
        {
            throw new NotImplementedException();
        }
    }

}
