using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain;
using Users.Domain.Enums;

namespace Users.Persistence.Configurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("users");
            builder.HasKey(dbModel => dbModel.Id).HasName("id");
            builder.HasIndex(dbModel => dbModel.Id).IsUnique();

            builder.Property(dbModel => dbModel.Code)
                .HasConversion(
                    role => role.ToString(),
                    field => (Role)Enum.Parse(typeof(Role), field))
                .HasDefaultValue(Role.User)
                .HasColumnName("code");
            builder.Property(dbModel => dbModel.Description).HasColumnName("description");
        }
    }
}