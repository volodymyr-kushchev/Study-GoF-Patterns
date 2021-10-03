using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Patterns.Iterator
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }
    }

    public class BinaryTree<T>
    {
        private Node<T> root;

        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                IEnumerable<Node<T>> TraverseInOrder(Node<T> current)
                {
                    if (current.Left != null)
                    {
                        foreach (var left in TraverseInOrder(current.Left))
                            yield return left;
                    }
                    yield return current;
                    if (current.Right != null)
                    {
                        foreach (var right in TraverseInOrder(current.Right))
                            yield return right;
                    }
                }

                var test = TraverseInOrder(root);
                foreach (var node in TraverseInOrder(root))
                    yield return node;
            }
        }
    }
}
