using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduktuVadymoSistema
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Pavadinimas: {Name}, Produkto aprasymas: {Description}, Kaina: {Price}";
        }
        //public Product(long Id, string Name, string Description, decimal Price)
        //{
        //    Id = Id;
        //    Name = Name;
        //    Description = Description;
        //    Price = Price;


        //}

    }
}
