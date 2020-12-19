using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentGraphicPostConfig : IEntityTypeConfiguration<GraphicPost>
    {
        public void Configure(EntityTypeBuilder<GraphicPost> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.Header).HasMaxLength(200).IsRequired();
            modelBuilder.Property(gp => gp.Image).IsRequired();
            modelBuilder.Property(gp => gp.Price).IsRequired();
            modelBuilder.Property(gp => gp.Active);
            modelBuilder.Property(gp => gp.CreateSlide);
            modelBuilder.Property(gp => gp.Text).IsRequired();
            //one to many relationship
            modelBuilder.HasOne(z => z.Customer).WithMany(z => z.GraphicPosts).HasForeignKey(z => z.CustomerId);
        }
    }
}
