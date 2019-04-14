using System;
using System.ComponentModel.DataAnnotations;

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

        public int CreatorId { get; set; }

        //possible validations https://docs.microsoft.com/pl-pl/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.7.2
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        public string PreparationTime { get; set; }
        public enum Difficulties { Easy, Medium, Hard }
        [EnumDataType(typeof(Difficulties))]
        public Difficulties difficulty { get; set; }

        public Recipe()
        {
        }
    }
}
