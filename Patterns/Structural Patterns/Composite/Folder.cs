using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns.Composite
{
    public class Folder : Component
    {
        List<Component> children;

        public Folder(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public override void Add(Component component)
        {
            if (children == null)
            {
                children = new List<Component>();
            }

            children.Add(component);
        }

        public override void Remove(Component component)
        {
            if (children == null)
            {
                return;
            }

            children.Remove(component);
        }

        public override int GetSize()
        {
            int overallSize = size;

            if (children == null)
            {
                return overallSize;
            }

            foreach (Component component in children)
            {
                overallSize += component.GetSize();
            }

            return overallSize;
        }
    }
}
