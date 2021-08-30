using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.SingletonVariants
{
    public class MultithreadSingleton : ISingleton
    {
        private static MultithreadSingleton instance = null;

        private static readonly object locker = new object();

        ISingleton ISingleton.GetInstance()
        {
            return MultithreadSingleton.GetInstance();
        }

        public static MultithreadSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new MultithreadSingleton();
                    }
                }
            }

            return instance;
        }

        public static void SomeSpecificLogic()
        {
            Console.WriteLine("Connection to remote sources...");
            Console.WriteLine("Gathering data...");
            Console.WriteLine("Success");
        }
    }
}
