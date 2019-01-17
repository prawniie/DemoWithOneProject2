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

        internal void AddCategoriesAndFruits()
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

        internal List<Fruit> GetAllFruitsInBasket(int id)
        {
            return _context.FruitInBasket.Where(x => x.BasketId == id).Include(x => x.Fruit).Select(x => x.Fruit).ToList(); //Måste använda Select för att säga vilken datatyp som ska returneras
        }

        internal List<Basket> GetBaskets()
        {
            return _context.Baskets.Include(x => x.FruitInBaskets).ToList();
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
            var torkad = new FruitCategory { Name = "Torkad" };
            var färsk = new FruitCategory { Name = "Färsk" };
            var mogen = new FruitCategory { Name = "Mogen" };

            //Lägg till variabler med olika frukter
            var nypon = new Fruit { Name = "Nypon", Category = färsk, Price = 29 };
            var päron = new Fruit { Name = "Päron", Category = mogen, Price = 9 };
            var ananas = new Fruit { Name = "Ananas", Category = färsk, Price = 39 };
            var aprikos = new Fruit { Name = "Aprikos", Category = mogen, Price = 12 };
            var apelsin = new Fruit { Name = "Apelsin", Category = färsk, Price = 8 };

            var basket1 = new Basket { Name = "Erikas nya korg" };

            var fib = new List<FruitInBasket>();
            fib.Add(new FruitInBasket { Fruit = nypon });
            fib.Add(new FruitInBasket { Fruit = päron });
            fib.Add(new FruitInBasket { Fruit = ananas });

            var basket2 = new Basket
            {
                Name = "Rebeckas nya korg",
                FruitInBaskets = new List<FruitInBasket>
                {
                    new FruitInBasket {Fruit = aprikos},
                    new FruitInBasket {Fruit = apelsin},
                    new FruitInBasket {Fruit = ananas}
                }
            };

            basket1.FruitInBaskets = fib;
            _context.Baskets.Add(basket1);
            _context.Baskets.Add(basket2);
            _context.SaveChanges();


        }

        internal List<Fruit> GetFruitsInCategory(string fruitCategory)
        {
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