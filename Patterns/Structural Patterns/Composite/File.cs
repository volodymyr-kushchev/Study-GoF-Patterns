using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns.Composite
{
    public class File : Component
    {
        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override int GetSize()
        {
            return size;
        }
    }
}
