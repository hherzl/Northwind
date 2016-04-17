using System;
using System.ComponentModel.DataAnnotations;
using Northwind.Core.EntityLayer;

namespace NorthwindMvc5.Areas.Reports.Models
{
    public class CategorySaleFor1997Model
    {
        public CategorySaleFor1997Model()
        {

        }

        public CategorySaleFor1997Model(CategorySaleFor1997 entity)
        {
            CategoryName = entity.CategoryName;
            CategorySales = entity.CategorySales;
        }

        [Display(Name = "Category name")]
        public String CategoryName { get; set; }

        [Display(Name = "Category sales")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public Decimal? CategorySales { get; set; }
    }
}
