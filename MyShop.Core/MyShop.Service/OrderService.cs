using MyShop.Core.Contacts;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Service
{
    public class OrderService : IorderService
    {
        IMRepository<Order> OrderContext;
        public OrderService(IMRepository<Order> OrderContext)
        {
            this.OrderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach(var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
            OrderContext.Insert(baseOrder);
            OrderContext.Commit();
        }
    }
}
