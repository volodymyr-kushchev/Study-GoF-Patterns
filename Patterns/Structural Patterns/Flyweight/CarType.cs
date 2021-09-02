using System;
using System.Drawing;

namespace Structural_Patterns.Flyweight
{
    // some game object data
    public class CarType
    {
        public readonly string model;
        // static pictures of car model the same for all car of same model
        public readonly Bitmap[] images = new Bitmap[1];

        public CarType(string model, Bitmap[] images)
        {
            this.model = model;
            images.CopyTo(this.images, 0);
        }
    }
}
