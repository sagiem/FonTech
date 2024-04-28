﻿using Microsoft.EntityFrameworkCore;
using FonTech.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FonTech.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x=> x.Login).IsRequired().HasMaxLength(100);
        builder.Property(x=> x.Password).IsRequired();

        builder.HasMany(x => x.Reports)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);
        
    }
}