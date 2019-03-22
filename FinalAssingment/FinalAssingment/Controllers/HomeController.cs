using FinalAssingment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssingment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This page is for site description.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Group 9 contect Page.";
            
            return View();
        }

        public ActionResult Products()
        {
            /*var products = new List<String>();
            //Create Products

            for (int i = 1; i <= 10; i++)
            {
                products.Add("Product" + i.ToString());
            }
            //Give products to the view to display it
            ViewBag.Products = products;
            */

            var products = new List<Product>() ;

            for (int i = 1; i <= 10; i++)
            {
                Product product = new Product();
                product.Name = "Product" + i.ToString();
                products.Add(product);
            }
                 
            //load the view
            return View(products);
        }

        public ActionResult FeedBack() {
            return View();
        }

        public ActionResult ProductInformation(String ProductName)
        {
            ViewBag.ProductName = ProductName;
            return View();
        }
    }
}