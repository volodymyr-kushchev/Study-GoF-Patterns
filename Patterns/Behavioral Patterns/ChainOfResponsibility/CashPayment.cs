using System;

namespace Behavioral_Patterns.ChainOfResponsibility
{
    public class CashPayment : IPayment
    {
        private IPayment nextPayment;

        public bool Pay(Payment payment)
        {
            if (payment.type == "CashPayment")
            {
                Console.WriteLine($"CashPayment: Payment is processing... You have payed {payment.money}");
                return true;
            }

            Console.WriteLine($"CashPayment skipped");

            if (nextPayment == null)
            {
                return false;
            }

            return nextPayment.Pay(payment);
        }

        public IPayment SetNext(IPayment paymentSystem)
        {
            nextPayment = paymentSystem;
            return nextPayment;
        }
    }
}
