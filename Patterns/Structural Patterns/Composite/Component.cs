
namespace Structural_Patterns.Composite
{
    public abstract class Component
    {
        public string name;

        public int size;

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract int GetSize();
    }
}
