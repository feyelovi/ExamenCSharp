using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    internal class Article
    {
        public int Id { get; set; }
        public string Code
        {
            get;
            set;
        }
        public string Name
        {
            get; set;
        }
        public string
            Description
        { get; set; }
        public string Brand
        {
            get;
            set;
        }
        public string
            Category
        { get; set; }
        public string
            Image
        { get; set; }
        public decimal Price { get; set; }

        public Article(int id, string code, string name, string description, string brand, string category, decimal price ,string image)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Brand = brand;
            Category = category;
            Price = price;
            Image = image;
        }
    }
}
