using System;
namespace example_mvc.Models
{
    public class Recipe
    {
        /// <summary>
        /// Corrected names of fields to first capital letters.
        /// Switched from private to public because scaffolding needed access to primary key. 
        /// Possible problems with security in the future?
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PreparationTime { get; set; }
        public enum Difficulties { Easy, Medium, Hard }
        public Difficulties difficulty { get; set; }

        public Recipe()
        {
        }
    }
}
