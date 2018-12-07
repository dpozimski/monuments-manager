using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monuments.Manager.Domain.Entities;

namespace Monuments.Manager.Persistence.Configurations
{
    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.HasKey(s => s.Id);

            builder.HasIndex(s => s.Email).HasName("IX_User_Email");

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.JobTitle)
                .HasMaxLength(50);

            builder.Property(s => s.FirstName)
                .HasMaxLength(100);

            builder.Property(s => s.LastName)
                .HasMaxLength(100);

            builder.Property(s => s.LastLoggedIn)
                .IsRequired();
        }
    }
}
