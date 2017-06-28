using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{

    public interface IverifyCardDetails
    {
        void ChargePayment(int CreditCardNumber, Decimal amount);
    }
   public class VerifyCardDetails:IverifyCardDetails
    {  
        
        public void  ChargePayment(int Creditcardnumber, Decimal amount)
        {

            using (var client = new HttpClient())
            {

               // string data;
                //taking mock url
                
                client.BaseAddress = new Uri("http://localhost:9000/");
                //posting card details to the third party payement gateway
             //   HttpResponseMessage response = await client("api/data", new string(data));
              //  response.EnsureSuccessStatusCode();

                // return URI of the created resource.
               
            }

        }
    }
}
