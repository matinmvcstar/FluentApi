using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.FluentConfig
{
    public class FluentGraphicPostCategoryConfig : IEntityTypeConfiguration<GraphicPostCategory>
    {
        public void Configure(EntityTypeBuilder<GraphicPostCategory> modelBuilder)
        {
            //Fluent API Many To Many Relatioship
            modelBuilder.HasKey(gpc => new { gpc.GraphicPostId, gpc.CategoryId });

            //Many To Many Relationship
            modelBuilder.HasOne(z => z.GraphicPost).WithMany(z => z.PostCategories).HasForeignKey(z => z.GraphicPostId);
            modelBuilder.HasOne(z => z.Category).WithMany(z => z.PostCategories).HasForeignKey(z => z.CategoryId);
        }
    }
}
