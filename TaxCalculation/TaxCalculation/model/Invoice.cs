using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation
{
    public class Invoice
    {
        public int Number { get; set; }

        private decimal _netAmount;
        private decimal _amount;
        private decimal _irrf;
        private decimal _pis;
        private decimal _cofins;
        private decimal _csll;
        private WithholdTaxesService _taxCalculationService;

        public decimal Amount { get { return _amount; } }
        public decimal IRRF { get { return _irrf; } }
        public decimal PIS { get { return _pis; } }
        public decimal COFINS { get { return _cofins; } }
        public decimal CSLL { get { return _csll; } }
        public decimal NetAmount { get { return _netAmount; } }

        public Invoice(int number, decimal amount, WithholdTaxesService taxCalculationService = null)
        {
            Number = number;
            _amount = amount;
            _taxCalculationService = taxCalculationService??WithholdTaxesService.GetInstance();
            this.TaxCalculation();
        }

        private void TaxCalculation()
        {
            WithholdTaxes _rates = _taxCalculationService.Get();

            decimal _irAmount = Math.Round(_amount * _rates.RateIRRF / 100, 2, MidpointRounding.AwayFromZero);
            if (_irAmount > 10)
            {
                _irrf = _irAmount;
            }
            if (_amount > 5000)
            {
                _pis = Math.Round(_amount * _rates.RatePIS / 100, 2, MidpointRounding.AwayFromZero);
                _cofins = Math.Round(_amount * _rates.RateCOFINS / 100, 2, MidpointRounding.AwayFromZero);
                _csll = Math.Round(_amount * _rates.RateCSLL / 100, 2, MidpointRounding.AwayFromZero);
            }

            _netAmount = Math.Round(_amount - (_irrf + _pis + _cofins + _csll), 2, MidpointRounding.AwayFromZero);
        }

        public void SetAmount(decimal amount)
        {
            _amount = amount;
            this.TaxCalculation();
        }
    }
}
