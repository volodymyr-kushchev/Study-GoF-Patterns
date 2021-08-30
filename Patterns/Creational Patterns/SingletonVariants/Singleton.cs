using Creational_Patterns.SingletonVariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.SingletonVariants
{
    public class Singleton: ISingleton
    {
        private static Singleton instance = null;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            System.Threading.Thread.Sleep(100);
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }

        public static void SomeSpecificLogic()
        {
            Console.WriteLine("Connection to remote source...");
            Console.WriteLine("Processing...");
            Console.WriteLine("Done");
        }

        ISingleton ISingleton.GetInstance()
        {
            return Singleton.GetInstance();
        }
    }
}
