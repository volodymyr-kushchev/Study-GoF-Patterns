
using System;

namespace Structural_Patterns.Adapter
{
    public class MP4
    {
        private double sound;

        public MP4() 
        {
            Console.WriteLine("MP4 constructor 0 parameters");
        }

        public MP4(double bits)
        {
            Console.WriteLine($"MP4 constructor 1 parameters - {bits}");
            sound = bits;
        }

        public virtual double Compress()
        {
            Console.WriteLine($"MP4 Compress result - {sound / 10}");
            return sound/10;
        }

        public virtual double Decompress()
        {
            Console.WriteLine($"MP4 Decompress result - {sound * 10}");
            return sound*10;
        }
    }
}
