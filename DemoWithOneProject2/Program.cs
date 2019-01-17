using System;
using System.Collections.Generic;

namespace DemoWithOneProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ClearAndInitDatabase();
            //DisplayAllFruits();
            //DisplayJustMognaFrukter();

            //AddFruitsToBasket();
            DisplayBasketsWithContent();

        }

        private static void DisplayBasketsWithContent()
        {
            var dataAccess = new DataAccess();
            List<Basket> listOfBaskets = dataAccess.GetBaskets();

            Console.WriteLine("VARUKORGAR\n");


            foreach (var basket in listOfBaskets)
            {
                Console.WriteLine(basket.Name.ToUpper());

                List<Fruit> fruitsInBasket = dataAccess.GetAllFruitsInBasket(basket.Id);

                foreach (var fruit in fruitsInBasket)
                {
                    Console.WriteLine(fruit.Name);
                }

                Console.WriteLine();
            }
        }

        private static void AddFruitsToBasket()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddFruitsInBasket();
            
        }

        private static void DisplayJustMognaFrukter()
        {
            var dataAccess = new DataAccess();
            List<Fruit> fruits = dataAccess.GetFruitsInCategory("Mogen");
            Console.WriteLine();
            Console.WriteLine("MOGNA FRUKTER");
            Console.WriteLine();

            foreach (var item in fruits)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void DisplayAllFruits()
        {
            var dataAccess = new DataAccess();

            foreach (Fruit item in dataAccess.GetAll())
            {
                Console.WriteLine(item.Id.ToString().PadRight(5) + item.Name.PadRight(15) + item.Price.ToString().PadRight(15) + item.Category.Name);
            }
        }

        private static void ClearAndInitDatabase()
        {
            var dataAccess = new DataAccess();
            dataAccess.AddCategoriesAndFruits();
            //dataAccess.ClearDatabase();
        }
    }
}
