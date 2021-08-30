using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational_Patterns.SingletonVariants
{
    public interface ISingleton
    {
        public ISingleton GetInstance();
    }
}
