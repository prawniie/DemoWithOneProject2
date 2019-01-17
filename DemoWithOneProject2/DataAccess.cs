using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoWithOneProject2
{
    internal class DataAccess
    {
        private readonly FruitContext _context;

        public DataAccess()
        {
          _context = new FruitContext();
        }

        internal void AddCateroriesAndFruits()
        {
            //_context.FruitCategories.Add(new FruitCategory { Name = "Färska" });
            //_context.FruitCategories.Add(new FruitCategory { Name = "Mogen" });
            //_context.FruitCategories.Add(new FruitCategory { Name = "Övermogen" });
            //_context.Fruits.Add(new Fruit { Name = "Banana", Category = new FruitCategory { Name = "Rutten" }});

            var torkad = new FruitCategory { Name = "Torkad" };
            var färsk = new FruitCategory { Name = "Färsk" };
            var mogen = new FruitCategory { Name = "Mogen" };

            //_context.FruitCategories.Add(torkad); överflödigt här då den fattar att man ska lägga till ny kategori pga koden nedan 

            //_context.Fruits.Add(new Fruit { Name = "Banana", Category = mogen, Price = 29});
            //_context.Fruits.Add(new Fruit { Name = "Äpple", Category = färsk, Price = 20 });
            //_context.Fruits.Add(new Fruit { Name = "Aprikos", Category = torkad, Price = 55 });

            _context.Fruits.Add(new Fruit { Name = "Physialis", Price = 30 });

           // _context.Fruits.Add(new Fruit { Name = "Äpple", Category = _context.FruitCategories.Where(x => x.Name == "Mogen").Select() });

            _context.SaveChanges();
        }

        internal List<Fruit> GetFruitsInCategory(string fruitCategory)
        {
            List<Fruit> fruits = new List<Fruit>();

            return _context.Fruits.Where(x => x.Category.Name == fruitCategory).Include(x => x.Category).ToList();
            //return _context.Fruits.Where(x => x.Category.Name == fruitCategory).Select(x=>new Fruit { Name=x.Name+"wwww"}).ToList();
            //fruits = _context.Fruits.Where(x => x.Category.Name == fruitCategory).ToList();
            //return fruits;
        }

        internal IEnumerable<Fruit> GetAll()
        {
            //return _context.Fruits.Where(s => s.Name != "").Include(s => s.Category);

            return _context.Fruits.Include(x => x.Category);
        }

        internal void ClearDatabase()
        {
            foreach (var fruit in _context.Fruits)
            {
                _context.Remove(fruit);
            }
            foreach (var category in _context.FruitCategories)
            {
                _context.Remove(category);
            }

            _context.SaveChanges();
        }
    }
}