using System;
namespace example_mvc.Models
{
    public class Recipe
    {
        private int Id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private string imageUrl { get; set; }
        private string preparationTime { get; set; }
        private enum difficulties { Easy, Medium, Hard}
        private difficulties difficulty { get; set; }

        public Recipe()
        {
        }
    }
}
