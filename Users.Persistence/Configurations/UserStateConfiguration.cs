using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain;
using Users.Domain.Enums;

namespace Users.Persistence.Configurations
{
    public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder.ToTable("users");
            builder.HasKey(dbModel => dbModel.Id).HasName("id");
            builder.HasIndex(dbModel => dbModel.Id).IsUnique();

            builder.Property(dbModel => dbModel.Code)
                .HasConversion(
                    status => status.ToString(),
                    field => (Status)Enum.Parse(typeof(Status), field))
                .HasDefaultValue(Status.Active)
                .HasColumnName("status");
            builder.Property(dbModel => dbModel.Description).HasColumnName("description");
        }
    }
}