using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialCalculationTests
{
    [TestClass]
    public class FinancialCalculatorTests
    {
        private FinancialCalculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new FinancialCalculator();
        }

        [TestMethod]
        public void Test_CalculateTimeWeightedRateOfReturn()
        {
            decimal[] returns = { 0.1m, 0.2m, -0.1m };
            decimal expected = 0.188m;
            decimal result = _calculator.CalculateTimeWeightedRateOfReturn(returns);
            Assert.AreEqual(expected, Math.Round(result, 3));
        }

        [TestMethod]
        public void Test_CalculateWACC()
        {
            decimal equity = 50000m;
            decimal debt = 20000m;
            decimal costOfEquity = 0.1m;
            decimal costOfDebt = 0.05m;
            decimal taxRate = 0.3m;
            decimal expected = 0.081m;
            decimal result = _calculator.CalculateWACC(equity, debt, costOfEquity, costOfDebt, taxRate);
            Assert.AreEqual(expected, Math.Round(result, 3));
        }

        [TestMethod]
        public void Test_CalculateYieldToMaturity()
        {
            decimal couponPayment = 1000m;
            decimal faceValue = 1000m;
            decimal marketPrice = 900m;
            int yearsToMaturity = 5;
            decimal expected = 1.0737m;
            decimal result = _calculator.CalculateYieldToMaturity(couponPayment, faceValue, marketPrice, yearsToMaturity);
            Assert.AreEqual(expected, Math.Round(result, 4));
        }

        [TestMethod]
        public void Test_CalculateFutureValueOfAnnuity()
        {
            decimal payment = 100m;
            decimal rate = 0.05m;
            int periods = 5;
            decimal expected = 552.56m;
            decimal result = _calculator.CalculateFutureValueOfAnnuity(payment, rate, periods);
            Assert.AreEqual(expected, Math.Round(result, 2));
        }

        [TestMethod]
        public void Test_CalculateEffectiveAnnualRate()
        {
            decimal nominalRate = 0.05m;
            int compoundingPeriods = 12;
            decimal expected = 0.0512m;
            decimal result = _calculator.CalculateEffectiveAnnualRate(nominalRate, compoundingPeriods);
            Assert.AreEqual(expected, Math.Round(result, 4));
        }

        [TestMethod]
        public void Test_CalculateCAPM()
        {
            decimal riskFreeRate = 0.03m;
            decimal beta = 1.2m;
            decimal marketReturn = 0.1m;
            decimal expected = 0.114m;
            decimal result = _calculator.CalculateCAPM(riskFreeRate, beta, marketReturn);
            Assert.AreEqual(expected, Math.Round(result, 3));
        }

        [TestMethod]
        public void Test_CalculateAnnualPercentageRate()
        {
            decimal totalFees = 100m;
            decimal loanAmount = 10000m;
            int loanTerm = 12;
            decimal interestRate = 0.05m;
            decimal expected = 50.00m;
            decimal result = _calculator.CalculateAnnualPercentageRate(totalFees, loanAmount, loanTerm, interestRate);
            Assert.AreEqual(expected, Math.Round(result, 2));
        }

        [TestMethod]
        public void Test_CalculateNetPresentValue()
        {
            decimal[] cashFlows = { -1000m, 300m, 300m, 300m, 300m };
            decimal discountRate = 0.1m;
            decimal expected = -49.04m;
            decimal result = _calculator.CalculateNetPresentValue(cashFlows, discountRate);
            Assert.AreEqual(expected, Math.Round(result, 2));
        }

        [TestMethod]
        public void Test_CalculateInternalRateOfReturn()
        {
            decimal[] cashFlows = { -1000m, 300m, 300m, 300m, 300m };
            decimal expected = 984.4794m;
            decimal result = _calculator.CalculateInternalRateOfReturn(cashFlows);
            Assert.AreEqual(expected, Math.Round(result, 4));
        }

        // Add additional tests for the remaining formulas here...

        // Example:
        [TestMethod]
        public void Test_CalculateReturnOnInvestment()
        {
            decimal gain = 200m;
            decimal cost = 1000m;
            decimal expected = -80.0m; // 20%
            decimal result = _calculator.CalculateReturnOnInvestment(gain, cost);
            Assert.AreEqual(expected, Math.Round(result, 2));
        }

        // Continue adding tests for all 30 methods...

        [TestMethod]
        public void Test_CalculateLoanAmortization()
        {
            decimal principal = 1000m;
            decimal annualRate = 0.05m;
            int totalPayments = 12;
            decimal expectedPayment = 85.61m; // Example expected payment
            decimal result = _calculator.CalculateLoanAmortization(principal, annualRate, totalPayments);
            Assert.AreEqual(expectedPayment, Math.Round(result, 2));
        }
    }
}
