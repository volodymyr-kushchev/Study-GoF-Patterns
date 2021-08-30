using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.Prototype
{
    public abstract class Gadget
    {
        private bool isForPeople;

        public Gadget() { }

        public Gadget(bool isForPeople) 
        {
            this.isForPeople = isForPeople;
        }

        public virtual Gadget ShallowCopy()
        {
            return this.MemberwiseClone() as Gadget;
        }

        public virtual Gadget DeepCopy()
        {
            return this.MemberwiseClone() as Gadget;
        }
    }
}
