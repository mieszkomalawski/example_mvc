using System;
using System.Collections.Generic;

namespace example_mvc.Models
{
    public class CreateRecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public string RecipeTags { get; set; } = "";
    }
}
