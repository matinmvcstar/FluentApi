using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentCoLogoConfig : IEntityTypeConfiguration<CoLogo>
    {
        public void Configure(EntityTypeBuilder<CoLogo> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.Image).IsRequired();
            modelBuilder.Property(gp => gp.Company).HasMaxLength(75).IsRequired();
            modelBuilder.Property(gp => gp.Address).HasMaxLength(450).IsRequired();
            modelBuilder.Property(gp => gp.Tell).HasMaxLength(10).IsRequired();
        }
    }
}
