
using System;

namespace Structural_Patterns.Adapter
{
    public class Adapter: MP4
    {
        private VLC sound;

        public Adapter(VLC sound): base(sound.Decompress())
        {
            this.sound = sound;
        }

        public override double Decompress()
        {
            Console.WriteLine($"Decompress of Adapter");
            return ConvertToMP4().Decompress();
        }

        private MP4 ConvertToMP4()
        {
            Console.WriteLine($"ConvertToMP4 of Adapter");
            return new MP4(this.sound.Decompress());
        }
    }
}
