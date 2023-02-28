using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Contacts
{
    public interface IorderService
    {
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);
    }
}
