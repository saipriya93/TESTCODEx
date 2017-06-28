using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IOrderService
    {
        bool TakeOrder(Order order);
    }
    public class OrderService : IOrderService
    {


        public readonly IproductInventory _invetoryrepo;
        public readonly EmailingSystem _email;

        public readonly VerifyCardDetails _carddetails;
        public OrderService(IproductInventory productrepo)
        {
            _email = new EmailingSystem();

            _invetoryrepo = new ProductInventory(new ProductRepo());
            _carddetails = new VerifyCardDetails();
        }

        public OrderService()
        {
        }

        public bool TakeOrder(Order order)
        {
            if (order.product != null)
            {
                var productavailable = _invetoryrepo.CheckInventory(order.product.ProductId, order.product.Quantity);
                if (productavailable)
                {
                    _carddetails.ChargePayment(order.CreditCardNo, order.product.Price);
                    _email.SendEmail(order);
                    return true;

                }

            }
            throw new ArgumentNullException("product not found");



        }
    }
}
    

