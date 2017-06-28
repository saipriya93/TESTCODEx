using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IProductRepo
    {
        List<Product> TotalListOfProducts();
       
    }
   public  class ProductRepo:IProductRepo
    {

        public List<Product> TotalListOfProducts()
        {
            return  new List<Product>()
            {
                new Product {ProductId=101,Quantity=80,Price=1030,ProductName="SamsungNote" },
                new Product {ProductId=103,Quantity=90,Price=12000,ProductName="apple6s" },
                new Product {ProductId=104,Quantity=100,Price=13000,ProductName="SamsungEdge" },
                new Product {ProductId=106,Quantity=110,Price=140000,ProductName="delllaptop" },
                new Product {ProductId=108,Quantity=70,Price=150000,ProductName="hplaptop" },
                new Product {ProductId=109,Quantity=40,Price=16000,ProductName="Iphone7s" },

            };
        }
    }
}
