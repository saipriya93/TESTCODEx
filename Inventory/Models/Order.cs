using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
   public class Order
    {
        public int orderid { get; set; }
        public int ordernum { get; set; }
        public Product product{ get; set; }
        public int Quantity { get; set; }
        public int CreditCardNo { get; set; }
        public string NameOnCard { get; set; }
        public Email Emailid { get; set;}
        

    }
}
