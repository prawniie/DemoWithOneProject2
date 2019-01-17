using System;
using System.Collections.Generic;

namespace DemoWithOneProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            //FruitContext context = new FruitContext();

            //ClearAndInitDatabase();
            DisplayAllFruits();
            DisplayJustMognaFrukter();

            //Migrationer: slippa rasera huset och bygga nytt; bara göra utbyggnad istället
            //Package manager console: Skriv Add-Migration Init
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
            dataAccess.AddCateroriesAndFruits();
            //dataAccess.ClearDatabase();
        }
    }
}
