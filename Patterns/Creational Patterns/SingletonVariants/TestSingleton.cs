using System;
using System.Threading;

namespace Creational_Patterns.SingletonVariants
{
    public static class TestSingleton 
    {
        public static void testSingleton()
        {
            ISingleton sqlDB = GetDB();
            ISingleton mongoDB = GetDB();

            if (sqlDB.GetHashCode() == mongoDB.GetHashCode())
            {
                Console.WriteLine("The instances are the same");
            }
            else
            {
                Console.WriteLine("Instances are different");
            }
        }

        public static void testMultithreadSingleton(bool isOneThread = false)
        {
            Thread connectSQL = new Thread(() =>
            {
                Console.WriteLine(GetDB(isOneThread).GetHashCode());
            });

            Thread connectMongo = new Thread(() =>
            {
                Console.WriteLine(GetDB(isOneThread).GetHashCode());
            });

            connectSQL.Start();
            connectMongo.Start();

            connectSQL.Join();
            connectMongo.Join();
        }

        static ISingleton GetDB(bool isOneThread = true)
        {
            if (isOneThread)
            {
                return Singleton.GetInstance();
            }

            return MultithreadSingleton.GetInstance();
        }
    }
}
