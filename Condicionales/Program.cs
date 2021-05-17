using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionales.Entities
{
   
    class Program
    {
        public enum MenuOptions
        {
            Exit = 0,
            createUser = 1,
            createProduct = 2,
            PrintCustomers = 3,
            PrintProducts = 4,
            HasDiscount = 5
        }
        static void Main(string[] args)
        {
            bool repeatMenu = true;
            int optionSelected;

            while (repeatMenu)
            {
                PrintMenu();
                Console.WriteLine("\n Choose an option:");
                optionSelected = Convert.ToInt32(Console.ReadLine());

                switch (optionSelected)
                {
                    case (int)MenuOptions.Exit:
                        repeatMenu = false;
                        break;
                    case (int)MenuOptions.createUser:
                        Console.WriteLine("Enter your name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter your age:");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Random randon = new Random();
                        string id = randon.Next(1, 1000).ToString();
                        Customer.CreateCustomer(id, name, age);
                        break;
                    case (int)MenuOptions.createProduct:
                        Console.WriteLine("Enter product name:");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Enter product category:");
                        string productCategory = Console.ReadLine();
                        Products.CreateProduct(productName, productCategory);
                        break;
                    case (int)MenuOptions.PrintCustomers:
                        Customer.PrintCustomers();
                        break;
                    case (int)MenuOptions.PrintProducts:
                        Products.PrintProducts();
                        break;
                    case (int)MenuOptions.HasDiscount:
                        Customer.PrintCustomers();
                        Console.WriteLine("Enter userID:");
                        string userId = Console.ReadLine();
                        Customer customer = Customer.getCustomer(userId);
                        bool hasDiscount = customer != null && Customer.HasMontlyBonus(customer);

                        if (hasDiscount)
                        {
                            Console.WriteLine("Customer with ID {0} has discount.", customer.id);
                        }
                        else
                        {
                            Console.WriteLine("Customer not found or has not discount.");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("--MENU--");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Create Product");
            Console.WriteLine("3. Print customers");
            Console.WriteLine("4. Print products");
            Console.WriteLine("5. Enter userID for check discount:");
            Console.WriteLine("0. Exit");
        }
        
    }
}
