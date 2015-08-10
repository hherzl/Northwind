using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Administration.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }

        public CategoryModel(Category entity)
        {
            CategoryID = entity.CategoryID;
            CategoryName = entity.CategoryName;
            Description = entity.Description;
            Picture = entity.Picture;
        }

        [Key]
        public Int32? CategoryID { get; set; }

        [Display(Name = "Category name")]
        [Required]
        [StringLength(30)]
        public String CategoryName { get; set; }

        [Display(Name = "Description")]
        [Required]
        public String Description { get; set; }

        [Display(Name = "Picture")]
        public Byte[] Picture { get; set; }
    }
}
