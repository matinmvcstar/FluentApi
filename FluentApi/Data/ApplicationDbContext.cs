using FluentApi.FluentConfig;
using FluentApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<GraphicPost> GraphicPosts { get; set; }

        public DbSet<GraphicPostCategory> GraphicPostCategories { get; set; }

        public DbSet<News> Newses { get; set; }

        public DbSet<NCategory> NCategories { get; set; }

        public DbSet<LearnPost> LearnPosts { get; set; }

        public DbSet<LCategory> LCategories { get; set; }

        public DbSet<Images> Imagess { get; set; }

        public DbSet<FileUp> FileUps { get; set; }

        public DbSet<CoLogo> CoLogos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseCollation("Persian_100_CI_AI");
            modelbuilder.ApplyConfiguration(new FluentGraphicPostCategoryConfig());
            modelbuilder.ApplyConfiguration(new FluentGraphicPostConfig());
            modelbuilder.ApplyConfiguration(new FluentCategoryConfig());
            modelbuilder.ApplyConfiguration(new FluentNewsConfig());
            modelbuilder.ApplyConfiguration(new FluentNCategoryConfig());
            modelbuilder.ApplyConfiguration(new FluentCoLogoConfig());
            modelbuilder.ApplyConfiguration(new FluentFileUpConfig());
            modelbuilder.ApplyConfiguration(new FluentLCategoryConfig());
            modelbuilder.ApplyConfiguration(new FluentLearnPostConfig());
            modelbuilder.ApplyConfiguration(new FluentImagesConfig());
            ///
            base.OnModelCreating(modelbuilder);
        }
    }
}
