
using System;

namespace Structural_Patterns.Adapter
{
    public class VLC
    {
        private double sound;

        public VLC() 
        {
            Console.WriteLine("VLC constructor 0 parameters");
        }

        public VLC(double bits)
        {
            Console.WriteLine($"VLC constructor 1 parameters - {bits}");
            sound = bits;
        }

        public virtual double Compress()
        {
            Console.WriteLine($"VLC Compress result - {sound / 5}");
            return sound/5;
        }

        public virtual double Decompress()
        {
            Console.WriteLine($"VLC Decompress result - {sound * 5}");
            return sound*5;
        }
    }
}
