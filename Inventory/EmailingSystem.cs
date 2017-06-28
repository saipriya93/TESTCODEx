using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class EmailingSystem
    {
        public  void SendEmail( Order order)
        {
            
            string to = "janet@abc.com";
            string from = "benet@OnlineShoppingServices.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "send the order to above mentioned Customer adress";
            message.Body = "send the order to the customer with invoice included";
            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreatingMessage2(): {0}", ex.ToString());
            }
        }
    }
}
