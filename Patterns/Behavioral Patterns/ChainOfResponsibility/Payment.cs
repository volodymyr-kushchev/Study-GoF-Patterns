using System;

namespace Behavioral_Patterns.ChainOfResponsibility
{
    public class Payment
    {
        public string type;
        public int money;

        public Payment(string type, int money)
        {
            this.type = type;
            this.money = money;
        }
    }
}
