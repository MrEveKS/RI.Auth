using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RI.Auth.Domain;
using RI.Auth.Domain.Models;

namespace RI.Auth.DataAccess.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .HasColumnType("character varying(50)")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName)
            .HasColumnType("character varying(100)")
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasColumnType("character varying(100)");
        builder.Property(e => e.MiddleName)
            .HasColumnType("character varying(100)");

        builder.Property(e => e.Description)
            .HasColumnType("character varying(500)");
        
        builder.Property(e => e.Age);

        builder.Property(e => e.Created)
            .HasPrecision(6)
            .HasDefaultValueSql("timezone('utc'::text, now())");
        builder.Property(e => e.Updated);
    }
}