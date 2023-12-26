using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusines.Validations
{
    internal class Product_EnsurePriceIsGreaterThanTheInventoriesPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if(product != null)
            {
                if(product.ValidatePrice())
                {
                    return new ValidationResult($"The Product Price is less than the summary of it's inventories's price : {product.TotalInventoryCost()}", new[] {validationContext.MemberName});
                }
            }
            return ValidationResult.Success;
        }
    }
}
