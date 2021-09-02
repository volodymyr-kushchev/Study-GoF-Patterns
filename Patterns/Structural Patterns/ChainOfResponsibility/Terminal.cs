using System;

namespace Structural_Patterns.ChainOfResponsibility
{
    public class Terminal
    {
        private IPayment currentPaymentSystem;

        public Terminal(IPayment payment)
        {
            currentPaymentSystem = payment;
        }

        public bool Pay(Payment payment)
        {
            return currentPaymentSystem.Pay(payment);
        }
    }
}
