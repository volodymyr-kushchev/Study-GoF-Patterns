using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns.Adapter
{
    public class MediaPlayer
    {
        public static void Play(MP4 sound)
        {
            Console.WriteLine("Play of MediaPlayer");
            double bits = sound.Decompress();
            Console.WriteLine($"Listen to this music - {bits}, isn't beautiful?");
        }
    }
}
