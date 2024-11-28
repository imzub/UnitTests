using System;
using Xunit;

namespace FinancialCalculationTests
{
    public class FinancialCalculatorTests : IDisposable
    {
        private readonly FinancialCalculator _calculator;

        public FinancialCalculatorTests()
        {
            _calculator = new FinancialCalculator();
        }

        public void Dispose()
        {
            // Clean up resources if necessary
        }

        [Fact]
        public void Test_CalculateTimeWeightedRateOfReturn()
        {
            decimal[] returns = { 0.1m, 0.2m, -0.1m };
            decimal expected = 0.188m;
            decimal result = _calculator.CalculateTimeWeightedRateOfReturn(returns);
            Assert.Equal(expected, Math.Round(result, 3));
        }

        [Fact]
        public void Test_CalculateWACC()
        {
            decimal equity = 50000m;
            decimal debt = 20000m;
            decimal costOfEquity = 0.1m;
            decimal costOfDebt = 0.05m;
            decimal taxRate = 0.3m;
            decimal expected = 0.081m;
            decimal result = _calculator.CalculateWACC(equity, debt, costOfEquity, costOfDebt, taxRate);
            Assert.Equal(expected, Math.Round(result, 3));
        }

        [Fact]
        public void Test_CalculateYieldToMaturity()
        {
            decimal couponPayment = 1000m;
            decimal faceValue = 1000m;
            decimal marketPrice = 900m;
            int yearsToMaturity = 5;
            decimal expected = 1.0737m;
            decimal result = _calculator.CalculateYieldToMaturity(couponPayment, faceValue, marketPrice, yearsToMaturity);
            Assert.Equal(expected, Math.Round(result, 4));
        }

        [Fact]
        public void Test_CalculateFutureValueOfAnnuity()
        {
            decimal payment = 100m;
            decimal rate = 0.05m;
            int periods = 5;
            decimal expected = 552.56m;
            decimal result = _calculator.CalculateFutureValueOfAnnuity(payment, rate, periods);
            Assert.Equal(expected, Math.Round(result, 2));
        }

        [Fact]
        public void Test_CalculateEffectiveAnnualRate()
        {
            decimal nominalRate = 0.05m;
            int compoundingPeriods = 12;
            decimal expected = 0.0512m;
            decimal result = _calculator.CalculateEffectiveAnnualRate(nominalRate, compoundingPeriods);
            Assert.Equal(expected, Math.Round(result, 4));
        }

        [Fact]
        public void Test_CalculateCAPM()
        {
            decimal riskFreeRate = 0.03m;
            decimal beta = 1.2m;
            decimal marketReturn = 0.1m;
            decimal expected = 0.114m;
            decimal result = _calculator.CalculateCAPM(riskFreeRate, beta, marketReturn);
            Assert.Equal(expected, Math.Round(result, 3));
        }

        [Fact]
        public void Test_CalculateAnnualPercentageRate()
        {
            decimal totalFees = 100m;
            decimal loanAmount = 10000m;
            int loanTerm = 12;
            decimal interestRate = 0.05m;
            decimal expected = 50.0m;
            decimal result = _calculator.CalculateAnnualPercentageRate(totalFees, loanAmount, loanTerm, interestRate);
            Assert.Equal(expected, Math.Round(result, 2));
        }

        [Fact]
        public void Test_CalculateNetPresentValue()
        {
            decimal[] cashFlows = { -1000m, 300m, 300m, 300m, 300m };
            decimal discountRate = 0.1m;
            decimal expected = -49.04m;
            decimal result = _calculator.CalculateNetPresentValue(cashFlows, discountRate);
            Assert.Equal(expected, Math.Round(result, 2));
        }

        [Fact]
        public void Test_CalculateInternalRateOfReturn()
        {
            decimal[] cashFlows = { -1000m, 300m, 300m, 300m, 300m };
            decimal expected = 0.1845m;
            decimal result = _calculator.CalculateInternalRateOfReturn(cashFlows);
            Assert.Equal(expected, Math.Round(result, 4));
        }

        // Add additional tests for the remaining formulas here...

        // Example:
        [Fact]
        public void Test_CalculateReturnOnInvestment()
        {
            decimal gain = 200m;
            decimal cost = 1000m;
            decimal expected = -80.0m; // 20%
            decimal result = _calculator.CalculateReturnOnInvestment(gain, cost);
            Assert.Equal(expected, Math.Round(result, 2));
        }

        // Continue adding tests for all 30 methods...

        [Fact]
        public void Test_CalculateLoanAmortization()
        {
            decimal principal = 1000m;
            decimal annualRate = 0.05m;
            int totalPayments = 12;
            decimal expectedPayment = 85.61m; // Example expected payment
            decimal result = _calculator.CalculateLoanAmortization(principal, annualRate, totalPayments);
            Assert.Equal(expectedPayment, Math.Round(result, 2));
        }
    }
}
