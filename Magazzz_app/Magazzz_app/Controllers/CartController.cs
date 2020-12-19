using Magazzz_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json;

namespace Magazzz_app.Controllers
{
    public class CartController : Controller
    {
        private ProductContext db;

        public CartController(ProductContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); 
            return View(cart);
        }

        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]); 
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart"))
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); 
            cart.CartLines.Add(db.Products.Find(ID)); 
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart)); 
            return Redirect("/"); 
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]); 
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("Cart")) 
                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart")); 
            cart.CartLines.RemoveAt(number); 
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart)); 
            return Redirect("/Cart"); 
        }
    }
}