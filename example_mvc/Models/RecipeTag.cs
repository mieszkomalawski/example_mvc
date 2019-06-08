using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example_mvc.Models
{
    public class RecipeTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Recipe Recipe { get; set; }
    }
}
