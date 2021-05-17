using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionales.Entities
{
    public enum StatusUser { Active = 1, Inactive = 2, Locked = 3 }
    public class Customer
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public double elderlyDiscount { get; set; }
        public StatusUser Status { get; set; }

        public static void CreateCustomer(string customerId, string customerName, int customerAge)
        {
            Customer newCustomer = new Customer();
            bool customerIsRegistered = false;

            foreach (var user in Data.Data.DataCustomer)
            {
                if (user.id == customerId)
                {
                    customerIsRegistered = true;
                    break;
                }
            }
            int elderAge = 60;
            if (customerAge >= elderAge && !customerIsRegistered)
            {
                newCustomer.elderlyDiscount = 0.2;
            }
            else
            {
                newCustomer.elderlyDiscount = 0;
            }

            if (!customerIsRegistered)
            {
                newCustomer.id = customerId;
                newCustomer.age = customerAge;
                newCustomer.name = customerName;
                newCustomer.Status = StatusUser.Active;
                Data.Data.DataCustomer.Add(newCustomer);
            }
        }
        
        public static void PrintCustomers()
        {
            foreach (var user in Data.Data.DataCustomer)
            {
                Console.WriteLine("Name: {0} Age: {1}", user.name, user.age);
            }
        }
    
    public virtual void CalculatePoints() { }

        bool HasMontlyBonus(Customer customer)
        {
            int elderAge = 60;
            if (customer.age >= elderAge
                && customer.Status == StatusUser.Active
                && customer.name.Contains("M"))
            {
                return true;
            }

            return false;
        }
    }
}
