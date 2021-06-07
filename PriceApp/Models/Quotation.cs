using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PriceApp.Models
{
    public class Quotation
    {
        //validation to make sure something was entered
        [Required(ErrorMessage = "Please enter a sale price.")]
        //validation to make sure something was entered that was greater than 0
        [Range(0,10000000,ErrorMessage = "Sale price must be greater than zero")]
        //property to hold the subtotal value
        public double? Subtotal { get; set; }
        //validation to make sure something was entered
        [Required(ErrorMessage = "Please enter a discount percent")]
        //validation to make sure the value was between 0 and 100
        [Range(0, 100, ErrorMessage = "The discount percent must be between 0 and 100")]
        //property to hold the discount percent value
        public double? DiscountPercent { get; set; }
        /// <summary>
        /// Takes the subtotal and discount percent and multiplies them to get the discount amount
        /// </summary>
        /// <returns></returns>
        public double CalculateDiscount()
        {
            //checks to make sure subtotal and discount percent got usable values
            if (Subtotal.HasValue && DiscountPercent.HasValue)
            {
                //multiplies the subtotal to the decimal version of the discount percent.
                return Subtotal.Value * (DiscountPercent.Value / 100);
            }
            //if the subtotal and discount percent didnt have values we return 0 for the discount amount.
            return 0;
        }
        /// <summary>
        /// calculates the total after subtracting the discount from the subtotal.
        /// </summary>
        /// <returns></returns>
        public double CalculateTotal()
        {
            //checks to make sure subtotal has a value
            if (Subtotal.HasValue)
            {
                //create variable called discount and assign it the result of calling the calculate discount method
                double discount = CalculateDiscount();
                //return the subtotal value minus the discount amount
                return Subtotal.Value - discount;
            }
            else
            {
                //if the subtotal didnt have a value, return 0
                return 0;
            }
        }
    }
}
