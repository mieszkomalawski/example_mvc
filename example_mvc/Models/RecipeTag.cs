using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace example_mvc.Models
{
    public class RecipeTag
    {
        [ForeignKey("Recipe")]
        public int Id { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Recipe Recipe { get; set; }
    }
}
