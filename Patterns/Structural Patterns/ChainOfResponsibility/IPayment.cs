using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns.ChainOfResponsibility
{
    public interface IPayment
    {
        public IPayment SetNext(IPayment paymentSystem);
        public bool Pay(Payment payment);
    }
}
