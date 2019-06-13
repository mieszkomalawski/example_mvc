using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace example_mvc.Models
{
    public class example_mvcContext : DbContext
    {
        public example_mvcContext(DbContextOptions<example_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<example_mvc.Models.Recipe> Recipes { get; set; }
        public DbSet<example_mvc.Models.Tag> Tags { get; set; }
        public DbSet<example_mvc.Models.RecipeTag> RecipeTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeTag>()
                .HasKey(c => new { c.Id, c.TagId });

           /* modelBuilder.Entity<RecipeTag>()
                .HasOne(rt => rt.Recipe)
                .WithMany(r => r.RecipeTags)
                .HasForeignKey(r => r.Id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RecipeTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.RecipeTags)
                .HasForeignKey(r => r.TagId)
                .OnDelete(DeleteBehavior.Restrict*/






        }
    }
}
