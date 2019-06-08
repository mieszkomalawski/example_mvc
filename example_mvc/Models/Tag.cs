using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example_mvc.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        
        public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
    }
}
