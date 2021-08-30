using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Prototype
{
    public class Laptop: Gadget
    {
        private double price;
        private string model;
        

        public Laptop(double price, string model, bool isForPeople) :base(isForPeople)
        {
            this.price = price;
            this.model = model;
        }

        public override Gadget DeepCopy()
        {
            return new Laptop(this.price, "copied " + this.model, true);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"name: {model}, price {price}");
        }
    }
}
