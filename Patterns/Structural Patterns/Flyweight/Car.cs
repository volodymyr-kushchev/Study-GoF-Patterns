using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns.Flyweight
{
    public class Car
    {
        public Color color;
        public readonly CarType type;

        public Car(CarType carType, Color color)
        {
            type = carType;
            this.color = color;
        }
    }
}
