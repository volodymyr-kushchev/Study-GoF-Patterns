using System;

namespace Structural_Patterns.ChainOfResponsibility
{
    public class CardPayment : IPayment
    {
        private IPayment nextPayment;

        public bool Pay(Payment payment)
        {
            if (payment.type == "CardPayment")
            {
                Console.WriteLine($"CardPayment: Payment is processing... You have payed {payment.money}");
                return true;
            }

            Console.WriteLine($"CardPayment skipped");

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
