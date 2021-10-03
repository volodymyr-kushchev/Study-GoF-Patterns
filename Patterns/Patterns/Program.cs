using System;
using System.Drawing;
using Creational_Patterns.Builder;
using Creational_Patterns.Prototype;
using Creational_Patterns.SingletonVariants;
using Structural_Patterns.Adapter;
using Behavioral_Patterns.ChainOfResponsibility;
using Structural_Patterns.Composite;
using Structural_Patterns.Flyweight;
using Behavioral_Patterns.Iterator;
using System.Linq;
using Behavioral_Patterns.Mediator;
using Behavioral_Patterns.Memento;
using Behavioral_Patterns.Visitor;

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
            //Flyweight();

            // поведенческие паттерны
            Console.WriteLine("Behavioral Patterns");
            ChainOfResonsibility();
            Iterator();
            Mediator();
            Memento();
            Visitor();
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

        static void Iterator()
        {
            Console.WriteLine("----------------Iterator----------------");
            var root = new Node<int>(1,
                new Node<int>(2),
                new Node<int>(3));

            var tree = new BinaryTree<int>(root);

            Console.WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));
        }

        static void Mediator()
        {
            Console.WriteLine("----------------Mediator----------------");
            var room = new ChatRoom();
            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi room!");
            jane.Say("hi John!");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("Hi, everyone!");

            jane.PrivateMessage(simon, "glad you could join to the chat");

            room.Leave(jane);

            simon.PrivateMessage(jane, "I managed to do it");

        }

        static void Memento()
        {
            Console.WriteLine("----------------Memento----------------");

            var ba = new BankAccount(100);
            var memento1 = ba.Deposit(50);
            var memento2 = ba.Deposit(46);

            Console.WriteLine(ba);

            ba.Restore(memento1);
            Console.WriteLine(ba);

            ba.Restore(memento2);
            Console.WriteLine(ba);
        }

        static void Visitor()
        {
            Console.WriteLine("----------------Visitor----------------");
            // классический посетитель (double dispatch)

            var e = new AdditionExpression(
                new DoubleExpression(1),
                new AdditionExpression(
                    new DoubleExpression(2),
                    new DoubleExpression(3)
                )
            );

            var ep = new ExpressionVisitor();
            ep.Visit(e);
            Console.WriteLine(ep);
        }
    }
}
