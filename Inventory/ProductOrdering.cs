using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{

    public class ProductOrdering
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }


    }
    public interface IproductInventory
    {
        bool CheckInventory(int productId, int qty);
    }

    public class ProductInventory : IproductInventory

    
    { 
        
        public readonly IProductRepo _repo;
     public ProductInventory(IProductRepo repo)
        {
            _repo = repo;
        }
        
        public bool CheckInventory(int productId, int qty)
        {
            var inventory = _repo.TotalListOfProducts().FirstOrDefault(t => t.ProductId == productId);
            if (inventory == null)
            {
                throw new ApplicationException("no such product is found");
            }

            var stock = _repo.TotalListOfProducts().Where(st => st.ProductId == productId &&
             st.Quantity <= inventory.Quantity);
            if (stock.Any())
            {
                Console.WriteLine("products are available for given  product id {0}", productId);
                return true;
            }
            Console.WriteLine("products quantity you mentioned are out of range");
            return false;
        }






    }
}