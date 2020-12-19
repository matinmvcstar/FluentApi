using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentImagesConfig : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.Text).HasMaxLength(50).IsRequired();
            modelBuilder.Property(gp => gp.ImagePost).IsRequired();
            //one to many relationship
            modelBuilder.HasOne(z => z.GraphicPost).WithMany(z => z.Images).HasForeignKey(z => z.GraphicPostId);
        }
    }
}
