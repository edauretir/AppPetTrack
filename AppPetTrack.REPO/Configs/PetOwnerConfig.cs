using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppPetTrack.REPO.Configs
{
    public class PetOwnerConfig : IEntityTypeConfiguration<PetOwner>
    {
        public void Configure(EntityTypeBuilder<PetOwner> builder)
        {
            builder.HasIndex(p => p.PhoneNumber).IsUnique();
        }
    }

}
