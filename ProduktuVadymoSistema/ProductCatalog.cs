using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktuVadymoSistema
{
    public class ProductCatalog
    {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private List<Product> products = new List<Product>();
        private int nextId = 1;

        public void AddProduct(Product product)
        {
            product.Id = nextId++;
            products.Add(product);
            Console.WriteLine("Poduktas pridetas.");
        }

        public void ShowAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void SearchProductByName(string name)
        {
            var foundProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundProducts.Any())
            {
                foreach (var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Nerasta produkto tokiu pavadinimu.");
            }
        }

        public void UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                Console.WriteLine("Produktas atnaujintas sekmingai.");
            }
            else
            {
                Console.WriteLine("Produktas nerastas.");
            }
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Produktas istrintas sekmingai.");
            }
            else
            {
                Console.WriteLine("Produktas nerastas.");
            }
        }

        public void SaveToFile(string fileName)
        {


            foreach (var product in products)
            {
                _streamWriter = new StreamWriter(fileName);
                _streamWriter.WriteLine($"{product.Id},{product.Name},{product.Description},{product.Price}");
                _streamWriter.Close();
            }

            Console.WriteLine("Produktai issaugoti i faila.");

        }


        public void ReadFromFile(string fileName)
        {
            _streamReader = new StreamReader(fileName);
            if (File.Exists(fileName))
            {
                products.Clear();
                nextId = 1;
                {

                    string line;
                    while ((line = _streamReader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var product = new Product
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],
                            Description = parts[2],
                            Price = decimal.Parse(parts[3])

                        };
                        Console.WriteLine(product);
                        products.Add(product);
                        nextId = Math.Max(nextId, product.Id + 1);
                    }
                    _streamReader.Close();
                    Console.WriteLine("Produtai perskaititi is failo.");
                }
            }
            else
            {
                Console.WriteLine("Failas nerastas.");
            }
                 
                
            
        }
    } 
}

