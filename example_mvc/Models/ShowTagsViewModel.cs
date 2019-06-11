using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example_mvc.Models
{
    public class ShowTagsViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<RecipeTag> RecipeTags { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
