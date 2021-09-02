using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Structural_Patterns.Flyweight
{
    public class CarFabric
    {
        List<CarType> carTypes;

        public CarFabric()
        {
            carTypes = new List<CarType>();
        }

        public CarType getCarType(string model, Bitmap[] images)
        {
            CarType type = new CarType(model, images);

            if (carTypes.Where(type => type.model == model).Count() > 0)
            {
                Console.WriteLine("Car type already exsist");
                return carTypes.Where(car => car.model == model).First();
            }

            Console.WriteLine("Car type doesn't exsist");
            carTypes.Add(type);

            return type;
        }
    }
}
