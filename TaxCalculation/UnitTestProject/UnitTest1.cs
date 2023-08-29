using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculation;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InvoiceWithoutTaxes()
        {
            Invoice _invoice = new Invoice(1, 300);

            Assert.AreEqual(0, _invoice.IRRF);
            Assert.AreEqual(0, _invoice.PIS);
            Assert.AreEqual(0, _invoice.COFINS);
            Assert.AreEqual(0, _invoice.CSLL);
            Assert.AreEqual(300, _invoice.NetAmount);
        }

        [TestMethod]
        public void InvoiceOnlyIRRF()
        {
            Invoice _invoice = new Invoice(1, 1000);

            Assert.AreEqual(15, _invoice.IRRF);
            Assert.AreEqual(0, _invoice.PIS);
            Assert.AreEqual(0, _invoice.COFINS);
            Assert.AreEqual(0, _invoice.CSLL);
            Assert.AreEqual(985, _invoice.NetAmount);
        }

        [TestMethod]
        public void InvoiceAllTaxes()
        {
            Invoice _invoice = new Invoice(1, 5200);

            Assert.AreEqual(78, _invoice.IRRF);
            Assert.AreEqual(156, _invoice.PIS);
            Assert.AreEqual(52, _invoice.COFINS);
            Assert.AreEqual(Convert.ToDecimal(33.8), _invoice.CSLL);
            Assert.AreEqual(Convert.ToDecimal(4880.2), _invoice.NetAmount);
        }

        [TestMethod]
        public void InvoiceAllTaxesWithRound()
        {
            Invoice _invoice = new Invoice(1, Convert.ToDecimal(5782.33));

            Assert.AreEqual(86.73m, _invoice.IRRF);
            Assert.AreEqual(Convert.ToDecimal(173.47), _invoice.PIS);
            Assert.AreEqual(Convert.ToDecimal(57.82), _invoice.COFINS);
            Assert.AreEqual(Convert.ToDecimal(37.59), _invoice.CSLL);
            Assert.AreEqual(Convert.ToDecimal(5426.72), _invoice.NetAmount);
        }

        [TestMethod]
        public void InvoiceAllTaxesWithOtherRates()
        {
            WithholdTaxesService _service = WithholdTaxesService.GetInstance();
            _service.SetTaxes(1, 2, 3, 4);
            Invoice _invoice = new Invoice(1, 5200, _service);

            Assert.AreEqual(52, _invoice.IRRF);
            Assert.AreEqual(104, _invoice.PIS);
            Assert.AreEqual(156, _invoice.COFINS);
            Assert.AreEqual(208, _invoice.CSLL);
            Assert.AreEqual(4680, _invoice.NetAmount);
        }

    }
}
