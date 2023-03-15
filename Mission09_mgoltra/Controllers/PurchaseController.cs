using Microsoft.AspNetCore.Mvc;
using Mission09_mgoltra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mgoltra.Controllers
{
    public class PurchaseController : Controller
    {

        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            //make sure there are items in the cart, if not, ask user to fill up the cart
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Cart is empty.");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else 
            {
                return View();
            }
        }
    }
}
