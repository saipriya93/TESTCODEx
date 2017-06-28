using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace InventoryUnitTest
{
    namespace InventoryUnit
    {
        [TestClass]
        public class InventoryTest
        {
            private IproductInventory _inventoryService;
            private Mock<IProductRepo> _mockProductRepository;
            private IOrderService _orderService;
            private IverifyCardDetails _paymentService;


            [TestMethod]
            public void TestProcessOrderWithProperOrderInfo()
            {
                var order = new Order
                {
                    product = new Product { ProductId = 2, Price = 43.6m, Quantity = 1, ProductName = "Test Product 2" },
                    Quantity = 3,
                    CreditCardNo = 313213,
                    orderid = 12,
                    NameOnCard = "Test Customer Name",
                    ordernum = 1589
                };
                var orderPlaced = _orderService.TakeOrder(order);
                Assert.AreEqual(orderPlaced, true);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException), "Inventory is out of this product")]
            public void TestProcessOrderWithOrderThathasNoProductsInInventory()
            {
                var order = new Order
                {
                    product = new Product { ProductId = 8, Price = 88.6m, Quantity = 1, ProductName = "Test Product 8" },
                    Quantity = 2,
                    CreditCardNo = 356335353,
                    orderid = 12,
                    NameOnCard = "Test Customer Name2",
                    ordernum = 2345
                };
                var orderPlaced = _orderService.TakeOrder(order);
            }

            [TestMethod]
            public void CheckIfGivenProductExistsInInventory()
            {
                var productExists = _inventoryService.CheckInventory(1, 3);
                Assert.AreEqual(productExists, true);
            }


            [TestInitialize]
            public void Initialize()
            {
                _mockProductRepository = new Mock<IProductRepo>();
                _inventoryService = new ProductInventory(_mockProductRepository.Object);
                _orderService = new OrderService();
                _paymentService = new VerifyCardDetails();

                var products = new List<Product>
            {
                new Product {ProductId = 1, Price = 22.6m, ProductName = "Test Product 1", Quantity = 12},
                new Product {ProductId = 2, Price = 43.6m, ProductName = "Test Product 2", Quantity = 7},
                new Product {ProductId = 3, Price = 67.6m, ProductName = "Test Product 3", Quantity = 1},
                new Product {ProductId = 4, Price = 49.8m, ProductName = "Test Product 4", Quantity = 3},
                new Product {ProductId = 5, Price = 18.2m, ProductName = "Test Product 5", Quantity = 9},
                new Product {ProductId = 6, Price = 11.1m, ProductName = "Test Product 6", Quantity = 13},
                new Product {ProductId = 7, Price = 33.6m, ProductName = "Test Product 7", Quantity = 22},
                new Product {ProductId = 8, Price = 88.6m, ProductName = "Test Product 8", Quantity = 0},
                new Product {ProductId = 9, Price = 22.2m, ProductName = "Test Product 9", Quantity = 19}
            };

                _mockProductRepository.Setup(mock => mock.TotalListOfProducts()).Returns(products);
               
            }
        }
    }
}
