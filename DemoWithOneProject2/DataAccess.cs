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

            var torkad = new FruitCategory { Name = "Torkad" };
            var färsk = new FruitCategory { Name = "Färsk" };
            var mogen = new FruitCategory { Name = "Mogen" };

            //_context.FruitCategories.Add(torkad); överflödigt här då den fattar att man ska lägga till ny kategori pga koden nedan 

            _context.Fruits.Add(new Fruit { Name = "Päron", Category = mogen, Price = 19 });
            _context.Fruits.Add(new Fruit { Name = "Apelsin", Category = färsk, Price = 25 });
            _context.Fruits.Add(new Fruit { Name = "Persika", Category = torkad, Price = 55 });

            _context.SaveChanges();
        }

        internal void AddFruitsInBasket()
        {
            //var torkad = new FruitCategory { Name = "Torkad" };
            //var färsk = new FruitCategory { Name = "Färsk" };
            //var mogen = new FruitCategory { Name = "Mogen" };

            //var fruit1 = new Fruit { Name = "Apelsin", Category = färsk, Price = 25 };
            //var fruit2 = new Fruit { Name = "Persika", Category = torkad, Price = 55 };

            //List<Fruit> listOfFruits = new List<Fruit>
            //{
            //    fruit1,
            //    fruit2
            //};

            var basket1 = new Basket { Name = "Erikas korg" };
            _context.Add(basket1);
            _context.SaveChanges();

            var newListOfErikasFruits = GetAll();

            FruitInBasket fruitInBasket = new FruitInBasket();

            foreach (var fruit in newListOfErikasFruits)
            {
                fruitInBasket.BasketId = basket1.Id;
                fruitInBasket.Basket = basket1;
                fruitInBasket.FruitId = fruit.Id;
                fruitInBasket.Fruit = fruit;
                _context.FruitInBasket.Add(fruitInBasket);
            }

            _context.SaveChanges();


        }

        internal List<Fruit> GetFruitsInCategory(string fruitCategory)
        {
            //return _context.Fruits.Where(x => x.Category.Name == fruitCategory).Include(x => x.Category).ToList();
            return  _context.Fruits.Where(x => x.Category.Name == fruitCategory).ToList();
        }

        internal IEnumerable<Fruit> GetAll()
        {
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