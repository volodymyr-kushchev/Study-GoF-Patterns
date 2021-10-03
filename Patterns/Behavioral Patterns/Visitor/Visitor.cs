using System.Text;

namespace Behavioral_Patterns.Visitor
{
    public interface IVisitor
    {
        public void Visit(DoubleExpression de);
        public void Visit(AdditionExpression ae);
    }

    public abstract class Expression
    {
        public abstract void Accept(IVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            this.Value = value;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class AdditionExpression: Expression
    {
        public Expression Left;
        public Expression Right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ExpressionVisitor : IVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            sb.Append(de.Value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.Left.Accept(this);
            sb.Append("+");
            ae.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
