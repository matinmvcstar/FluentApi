using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentFileUpConfig : IEntityTypeConfiguration<FileUp>
    {
        public void Configure(EntityTypeBuilder<FileUp> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.UrlFile).IsRequired();
            modelBuilder.Property(gp => gp.UrlFile).HasMaxLength(75).IsRequired();
        }
    }
}
