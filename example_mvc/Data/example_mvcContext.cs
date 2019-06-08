﻿using System;
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

        public DbSet<example_mvc.Models.Recipe> Recipe { get; set; }
        public DbSet<example_mvc.Models.Tag> Tag { get; set; }
        public DbSet<example_mvc.Models.RecipeTag> RecipeTag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeTag>()
                .HasKey(c => new { c.Id, c.TagId });


        }
    }
}
