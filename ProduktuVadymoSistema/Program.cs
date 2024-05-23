using ProduktuVadymoSistema;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        ProductCatalog catalog = new ProductCatalog();
        string fileName = "products.txt";

        while (true)
        {
            Console.WriteLine("Pasirinkite opcija:");
            Console.WriteLine("1. Prideti nauja produkta");
            Console.WriteLine("2. Rodyti visus productus");
            Console.WriteLine("3. Ieskoti produkto pagal pavadinima");
            Console.WriteLine("4. Atnaujinti produkto informacija");
            Console.WriteLine("5. Istrinti produkta");
            Console.WriteLine("6. Issaugoti produktus i faila");
            Console.WriteLine("7. Skaititi produktus is failo");
            Console.WriteLine("8. Iseiti");
            Console.Write("Pasirinkimas: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Iveskite produkto pavadinima: ");
                    string name = Console.ReadLine();
                    Console.Write("Iveskite produkto aprasyma: ");
                    string description = Console.ReadLine();
                    Console.Write("Iveskite produkto kaina : ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    catalog.AddProduct(new Product { Name = name, Description = description, Price = price });
                    break;

                case "2":
                    catalog.ShowAllProducts();
                    break;

                case "3":
                    Console.Write("Ivekite produkto pavadinima kurio ieskote: ");
                    string searchName = Console.ReadLine();
                    catalog.SearchProductByName(searchName);
                    break;

                case "4":
                    Console.Write("Iveskite produkto ID kuri norite atnaujinti: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Iveskite nauja produkto pavadinima: ");
                    string updateName = Console.ReadLine();
                    Console.Write("Apibudinkite nauja produkta: ");
                    string updateDescription = Console.ReadLine();
                    Console.Write("Iveskite naujo produkto kaina: ");
                    decimal updatePrice = decimal.Parse(Console.ReadLine());
                    catalog.UpdateProduct(updateId, new Product { Name = updateName, Description = updateDescription, Price = updatePrice });
                    break;

                case "5":
                    Console.Write("Iveskite produkto ID kuri norite istrinti: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    catalog.DeleteProduct(deleteId);
                    break;

                case "6":
                    catalog.SaveToFile(fileName);
                    break;

                case "7":
                    catalog.ReadFromFile(fileName);
                    break;

                case "8":
                    return;

                default:
                    Console.WriteLine("Netinkamas pasirinkimas. Bandykite dar karta.");
                    break;
            }
        }
    }
}
