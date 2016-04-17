using System;
using Northwind.Core.EntityLayer;

namespace NorthwindApi.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }

        public CategoryViewModel(Category entity)
        {
            CategoryID = entity.CategoryID;
            CategoryName = entity.CategoryName;
            Description = entity.Description;
        }

        public Int32? CategoryID { get; set; }

        public String CategoryName { get; set; }

        public String Description { get; set; }

        public Category ToEntity()
        {
            return new Category()
            {
                CategoryID = CategoryID,
                CategoryName = CategoryName,
                Description = Description
            };
        }
    }
}
