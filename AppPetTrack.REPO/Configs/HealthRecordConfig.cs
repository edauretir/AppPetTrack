using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPetTrack.REPO.Configs
{
    public class HealthRecordConfig : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            throw new NotImplementedException();
        }
    }

}
