using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;
using NorthwindMvc5.Resources;

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

        [Display(Name = "CategoryName", ResourceType = typeof(CategoryResource))]
        [Required(ErrorMessageResourceName = "CategoryNameRequired", ErrorMessageResourceType = typeof(CategoryResource))]
        [StringLength(30, ErrorMessageResourceName = "CategoryNameStringLength", ErrorMessageResourceType = typeof(CategoryResource))]
        public String CategoryName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(CategoryResource))]
        public String Description { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(CategoryResource))]
        public Byte[] Picture { get; set; }
    }
}
