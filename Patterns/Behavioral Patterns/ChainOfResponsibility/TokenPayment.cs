using System;

namespace Behavioral_Patterns.ChainOfResponsibility
{
    public class TokenPayment: IPayment
    {
        private IPayment nextPayment;

        public bool Pay(Payment payment)
        {
            if (payment.type == "TokenPayment")
            {
                Console.WriteLine($"TokenPayment: Payment is processing... You have payed {payment.money}");
                return true;
            }

            Console.WriteLine($"TokenPayment skipped");

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
