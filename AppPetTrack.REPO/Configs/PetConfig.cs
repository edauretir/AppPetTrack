using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AppPetTrack.REPO.Configs
{
    public class PetConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            //builder.HasOne(p => p.Alert).WithOne(h => h.Pet).HasForeignKey<Pet>(x => x.Id);
            //builder.HasOne(p => p.TrackerDevice).WithOne(h => h.Pet).HasForeignKey<Pet>(x => x.Id);
        }
    }

}
