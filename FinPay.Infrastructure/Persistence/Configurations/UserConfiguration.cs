using FinPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPay.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint");


        builder.Property(x => x.FirstName)
               .HasColumnName("first_name")
               .HasColumnType("varchar(50)");

        builder.Property(x => x.LastName)
               .HasColumnName("last_name")
               .HasColumnType("varchar(50)");

        builder.Property(x => x.PhoneNumber)
               .HasColumnName("phone_number")
               .HasColumnType("varchar(20)");

        builder.Property(x => x.Email)
               .HasColumnName("email")
               .HasColumnType("varchar(30)");

        builder.Property(x => x.Password)
               .HasColumnName("password")
               .HasColumnType("varchar(255)");
    }
}