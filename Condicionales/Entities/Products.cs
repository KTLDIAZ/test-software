using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condicionales.Entities
{
    public class ProductsCategory 
    {
        public const string drinks = "drinks"; 
    }
    public class Products
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public bool payTax { get; set; }

        public static void CreateProduct(string name, string category)
        {
            Products newProduct = new Products();
            Random randon = new Random();
            bool productIsRegistered = false;

            foreach (var product in Data.Data.DataProducts)
            {
                if (product.name == name)
                {
                    productIsRegistered = true;
                    break;
                }
            }

            if (!productIsRegistered)
            {
                newProduct.payTax = category == ProductsCategory.drinks ? true : false;
                newProduct.id = randon.Next(1, 1000).ToString();
                newProduct.name = name;
                newProduct.category = category;
                Data.Data.DataProducts.Add(newProduct);
            }
        }
        public static void PrintProducts()
        {
            foreach (var product in Data.Data.DataProducts)
            {
                Console.WriteLine("Name: {0} Category: {1}", product.name, product.category);
            }
        }

    }
    

}
