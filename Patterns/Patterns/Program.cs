using System;
using System.Drawing;
using Creational_Patterns.Builder;
using Creational_Patterns.Prototype;
using Creational_Patterns.SingletonVariants;
using Structural_Patterns.Adapter;
using Behavioral_Patterns.ChainOfResponsibility;
using Structural_Patterns.Composite;
using Structural_Patterns.Flyweight;

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
            Composite();
            Flyweight();

            // поведенческие паттерны
            Console.WriteLine("Behavioral Patterns");
            ChainOfResonsibility();
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

        static void Composite()
        {
            Console.WriteLine("----------------Composite----------------");
            Component txtFile = new File("Readme.txt", 10);
            Component imgFile = new File("DemonSlayer.png", 1000);
            Component downloads = new Folder("Downloads", 0);
            downloads.Add(txtFile);
            downloads.Add(imgFile);
            Component vsSettings = new File("vsSettings.st", 300);
            Component project = new File("Project.proj", 100);
            Component stared = new Folder("Stared", 0);
            stared.Add(project);
            stared.Add(vsSettings);
            downloads.Add(stared);
            Console.WriteLine($"Size of folder - {downloads.GetSize()}");
        }

        static void Flyweight()
        {
            Console.WriteLine("----------------Flyweight----------------");
            CarFabric factory = new CarFabric();
            var type = factory.getCarType("audi", new Bitmap[] { new Bitmap(@"Y:\budapest-photo.jpg") });

            Car audi = new Car(type, Color.White);
            Car audi2 = new Car(factory.getCarType("audi", new Bitmap[] { new Bitmap(@"Y:\budapest-photo.jpg") }), Color.Black);
        }

        static void ChainOfResonsibility()
        {
            Console.WriteLine("----------------Chain of Responsibility----------------");
            Payment transfer1 = new Payment("TokenPayment", 100);

            CardPayment cardPayment = new CardPayment();
            CardPayment cardPayment2 = new CardPayment();
            CashPayment cashPayment = new CashPayment();
            TokenPayment tokenPayment = new TokenPayment();

            cardPayment.SetNext(cardPayment2).SetNext(cashPayment).SetNext(tokenPayment);

            Terminal terminal = new Terminal(cardPayment);

            terminal.Pay(transfer1);
        }
    }
}
