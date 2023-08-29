using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class WithholdTaxes
    {
        public decimal RateIRRF { get; set; }

        public decimal RatePIS { get; set; }

        public decimal RateCOFINS { get; set; }

        public decimal RateCSLL { get; set; }

        public decimal RateAggregate
        {
            get
            {
                return RatePIS + RateCOFINS + RateCSLL;
            }
        }
    }
}
