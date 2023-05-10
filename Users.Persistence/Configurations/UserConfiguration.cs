using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain;

namespace Users.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(dbModel => dbModel.Id).HasName("id");
            builder.HasIndex(dbModel => dbModel.Id).IsUnique();

            builder.Property(dbModel => dbModel.UserGroupId).HasColumnName("user_group_id");
            builder.Property(dbModel => dbModel.UserStateId).HasColumnName("user_state_id");
            builder.Property(dbModel => dbModel.Login).IsUnicode().HasColumnName("login");
            builder.Property(dbModel => dbModel.Password).HasColumnName("password");
            builder.Property(dbModel => dbModel.CreatedDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd()
                .HasColumnName("created_date");

            builder.HasOne(dbModel => dbModel.UserGroup)
                .WithOne(dbModel => dbModel.User)
                .HasForeignKey<User>(dbModel => dbModel.UserGroupId);

            builder.HasOne(dbModel => dbModel.UserState)
                .WithOne(dbModel => dbModel.User)
                .HasForeignKey<User>(dbModel => dbModel.UserStateId);
        }
    }
}