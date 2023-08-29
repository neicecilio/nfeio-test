using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice _invoice01 = new Invoice(1, 1000);
            Invoice _invoice02 = new Invoice(1, 5000);
            Invoice _invoice03 = new Invoice(1, 5200);
            Invoice _invoice04 = new Invoice(1, 300);

            Console.ReadKey();

            _invoice04.SetAmount(1500);

            Console.ReadKey();
        }
    }
}
