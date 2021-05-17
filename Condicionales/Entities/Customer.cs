using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionales.Entities
{
    public enum StatusUser { Active = 1, Inactive = 2, Locked = 3 }
    public class ElderDiscount 
    {
        public const int elderly = 60;
    }
    static class  Discount 
    {
        public const int twenty = 02;
        public const int zero = 0;
    }
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
            if (customerAge >= ElderDiscount.elderly && !customerIsRegistered)
            {
                newCustomer.elderlyDiscount = Discount.twenty;
            }
            else
            {
                newCustomer.elderlyDiscount = Discount.zero;
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
                Console.WriteLine("userID: {0} Name: {1} Age: {2}", user.id, user.name, user.age);
            }
        }

        public static Customer getCustomer(string customerId)
        {
            Customer customer = new Customer();
            foreach (var user in Data.Data.DataCustomer)
            {
                if (user.id == customerId)
                {
                    customer =  user;
                    break;
                }
            }
            return customer;
        }
    
    public virtual void CalculatePoints() { }

      public static bool HasMontlyBonus(Customer customer)
        {
            if (customer.age >= ElderDiscount.elderly
                && customer.Status == StatusUser.Active)
            {
                return true;
            }

            return false;
        }
    }
}
