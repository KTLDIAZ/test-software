using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionales.Entities
{
    public class OperationsSuperMarket
    {
        void CalculatePoints(Customer customer)
        {
            switch (customer.Status)
            {
                case StatusUser.Active:
                    Console.WriteLine("Active User");
                    break;
                case StatusUser.Inactive:
                    Console.WriteLine("Inactive User");
                    break;
                case StatusUser.Locked:
                    Console.WriteLine("Lock User");
                    break;
                default:
                    break;
            }

        }
    }
}
