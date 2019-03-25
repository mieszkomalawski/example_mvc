using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace example_mvc.Models
{
    public class MvcRecipeContext : DbContext
    {
        public MvcRecipeContext(DbContextOptions<MvcRecipeContext> options)
            : base(options)
        {
        }

        public DbSet<example_mvc.Models.Recipe> Recipe { get; set; }
    }
}
