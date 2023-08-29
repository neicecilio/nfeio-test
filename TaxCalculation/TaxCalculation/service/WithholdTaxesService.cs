using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class WithholdTaxesService
    {
        private static readonly WithholdTaxesService instance = new WithholdTaxesService();
        private WithholdTaxes _taxes = new WithholdTaxes();

        private WithholdTaxesService()
        {
            //TODO: Get from a database configuration
            _taxes.RateIRRF = Convert.ToDecimal(1.5);
            _taxes.RatePIS = 3;
            _taxes.RateCOFINS = 1;
            _taxes.RateCSLL = Convert.ToDecimal(0.65);
        }

        public static WithholdTaxesService GetInstance()
        {
            return instance;
        }

        public WithholdTaxes Get()
        {
            return _taxes;
        }

        public bool SetTaxes(decimal RateIRRF, decimal RatePIS, decimal RateCOFINS, decimal RateCSLL)
        {
            try
            {
                _taxes.RateIRRF = RateIRRF;
                _taxes.RatePIS = RatePIS;
                _taxes.RateCOFINS = RateCOFINS;
                _taxes.RateCSLL = RateCSLL;
            }
            catch
            {
                throw;
            }

            return true;
        }
    }
}
