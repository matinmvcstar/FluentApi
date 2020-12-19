using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentLearnPostConfig : IEntityTypeConfiguration<LearnPost>
    {
        public void Configure(EntityTypeBuilder<LearnPost> modelBuilder)
        {
            modelBuilder.HasKey(gp => gp.Id);
            modelBuilder.Property(gp => gp.Header).HasMaxLength(200).IsRequired();
            modelBuilder.Property(gp => gp.Image).IsRequired();
            modelBuilder.Property(gp => gp.Image2).IsRequired();
            modelBuilder.Property(gp => gp.Video).IsRequired();
            modelBuilder.Property(gp => gp.Active);
            modelBuilder.Property(gp => gp.CreateSlide);
            modelBuilder.Property(gp => gp.Text).IsRequired();
            modelBuilder.Property(gp => gp.Text2).IsRequired();
            modelBuilder.Property(gp => gp.Text3).IsRequired();
            //One to One Relationship
            modelBuilder.HasOne(z => z.LCategory).WithMany(z => z.LearnPosts).HasForeignKey(z => z.LCategoryId);
        }
    }
}
