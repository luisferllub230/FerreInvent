using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModel.Products
{
    public class SaveProductViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "product name is required")]
        public string productName { get; set; }

        [Required(ErrorMessage = "product description is required")]
        public string productDescription { get; set; }

        [Required(ErrorMessage = "product img is required")]
        public string productImg { get; set; }

        [Required(ErrorMessage = "product price is required")]
        public double productPrice { get; set; }

        [Required(ErrorMessage = "product category is required")]
        public int categoryId { get; set; }
    }
}
