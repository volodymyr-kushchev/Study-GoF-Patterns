using System;
using Creational_Patterns.Builder;
using Creational_Patterns.Prototype;
using Creational_Patterns.SingletonVariants;
using Structural_Patterns.Adapter;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {   
            // порождающие паттерны
            Console.WriteLine("Creational Patterns");
            Singleton();
            Prototype();
            Builder();

            // структурные паттерны
            Console.WriteLine("Strutural Patterns");
            Adapter();
        }

        static void Singleton()
        {
            Console.WriteLine("----------------Singleton----------------");
            TestSingleton.testSingleton();
            TestSingleton.testMultithreadSingleton(isOneThread: false);
        }

        static void Prototype()
        {
            Console.WriteLine("----------------Prototype----------------");
            Gadget phone = new Laptop(800, "note 10 pro", true);
            Gadget iphone = new Laptop(1000, "iphone 12 pro", true);
            Gadget nokia = new Laptop(130, "nokia", true);

            Laptop xiaomi = phone.ShallowCopy() as Laptop;
            xiaomi.DisplayInfo();
            xiaomi = iphone.ShallowCopy() as Laptop;
            xiaomi.DisplayInfo();
            xiaomi = (iphone).DeepCopy() as Laptop;
            xiaomi.DisplayInfo();
        }

        static void Builder()
        {
            Console.WriteLine("----------------Builder----------------");
            IBuilder builder = new HouseBuilder();
            Manager manager = new Manager(builder);

            try
            {
                manager.BuildHouse();
                Console.WriteLine("house had been built by someone");
                manager.ChangeBuilder(new HotelBuilder());
                Console.WriteLine("hotel is ready to use");
                manager.BuildHotel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Adapter()
        {
            Console.WriteLine("----------------Adapter----------------");
            VLC vlcSound = new VLC(10);
            Adapter adaptedMP4 = new Adapter(vlcSound);

            MediaPlayer.Play(adaptedMP4);
        }
    }
}
