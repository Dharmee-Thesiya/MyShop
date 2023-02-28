using MyShop.Core.Contacts;
using MyShop.Core.Models;
using MyShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IorderService OrderService;
        public BasketController(IBasketService BasketService, IorderService OrderService)
        {
            this.basketService = BasketService;
            this.OrderService = OrderService;

        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);

            return View(model);
        }
        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");

        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");

        }
        public PartialViewResult BasketSummary()
        {
            var basketsummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketsummary);
        }
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order Order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            Order.OrderStatus = "Order Created";


            //Process Payment

            Order.OrderStatus = "Payment Processed";
            OrderService.CreateOrder(Order, basketItems);
            basketService.ClearBasket(this.HttpContext);
            return RedirectToAction("ThankYou", new { OrderId = Order.Id });
        }
        public ActionResult Thankyou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }

        }
    }