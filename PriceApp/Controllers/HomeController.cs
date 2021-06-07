using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PriceApp.Models;

namespace PriceApp.Controllers
{
    public class HomeController : Controller
    {
        //expects an html get request
        [HttpGet]
        public IActionResult Index()
        {
            //initializes the discount value to 0
            ViewBag.Discount = 0;
            //initializes the total value to 0
            ViewBag.Total = 0;   
            //returns the view
            return View();
        }

        [HttpPost]
        public IActionResult Index(Quotation quote)
        {
            //checks to make sure there were no errors with the validation
            if (ModelState.IsValid)
            {
                //change the viewbag.discount to the calculated value from the calculatediscount() method in the quotation class
                ViewBag.Discount = quote.CalculateDiscount();
                //change the viewbag.total to the calculated value from the calculatetotal() method in the quotation class
                ViewBag.Total = quote.CalculateTotal();
            }
            else
            {
                //these values return to 0 if there were validation errors
                ViewBag.Discount = 0;
                //these values return to 0 if there were validation errors
                ViewBag.Total = 0;
            }
            //returns the view with the class values that were used.
            return View(quote);
        }
    }
}
