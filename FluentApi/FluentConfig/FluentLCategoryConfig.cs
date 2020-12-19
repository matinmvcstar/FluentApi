using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentLCategoryConfig : IEntityTypeConfiguration<LCategory>
    {
        public void Configure(EntityTypeBuilder<LCategory> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.CategoryName).HasMaxLength(50).IsRequired();
        }
    }
}
