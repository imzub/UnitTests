using NUnit.Framework;

[TestFixture]
public class FinancialCalculatorTests
{
    private FinancialCalculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new FinancialCalculator();
    }

    [Test, Sequential]
    public void Test_CalculateCompoundInterest(
        [Values(1000.0)] decimal principal,
        [Values(0.05)] decimal rate,
        [Values(5)] int time,
        [Values(1)] int frequency,
        [Values(1276.28)] decimal expected)
    {
        decimal result = _calculator.CalculateCompoundInterest(principal, rate, time, frequency);
        Assert.That(expected == result);
    }

    [Test, Sequential]
    public void Test_CalculateFutureValueOfAnnuity(
        [Values(100)] decimal payment,
        [Values(0.05)] decimal rate,
        [Values(5)] int periods,
        [Values(552.56)] decimal expected)
    {
        decimal result = _calculator.CalculateFutureValueOfAnnuity(payment, rate, periods);
        Assert.IsTrue(expected == result);
    }

    [Test, Sequential]
    public void Test_CalculatePresentValueOfAnnuity(
        [Values(100)] decimal payment,
        [Values(0.05)] decimal rate,
        [Values(5)] int periods,
        [Values(432.95)] decimal expected)
    {
        decimal result = _calculator.CalculatePresentValueOfAnnuity(payment, rate, periods);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateNetPresentValue(
        [Values(-1000, 300, 300, 300, 300)] decimal cashFlow1,
        [Values(0.05,0.04,0.01,0.3,0.9)] decimal discountRate,
        [Values(63.79, 1388.97, 1470.59, 949.87, 607.76)] decimal expected)
    {
        decimal[] cashFlows = { cashFlow1, 300, 300, 300, 300 };
        decimal result = _calculator.CalculateNetPresentValue(cashFlows, discountRate);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateInternalRateOfReturn(
        [Values(-1000, 300, 300, 300, 300)] decimal cashFlow1,
        [Values(984.4794, -305.9981, -305.9981, -305.9981, -305.9981)] decimal expected)
    {
        decimal[] cashFlows = { cashFlow1, 300, 300, 300, 300 };
        decimal result = _calculator.CalculateInternalRateOfReturn(cashFlows);
        Assert.AreEqual(expected, Math.Round(result, 4));
    }

    [Test, Sequential]
    public void Test_CalculateLoanAmortization(
        [Values(10000)] decimal principal,
        [Values(0.05)] decimal rate,
        [Values(60)] int periods,
        [Values(188.71)] decimal expected)
    {
        decimal result = _calculator.CalculateLoanAmortization(principal, rate, periods);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }

    [Test, Sequential]
    public void Test_CalculateDebtToIncomeRatio(
        [Values(500)] decimal totalDebt,
        [Values(2000)] decimal totalIncome,
        [Values(25.0)] decimal expected)
    {
        decimal result = _calculator.CalculateDebtToIncomeRatio(totalDebt, totalIncome);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateCashFlow(
        [Values(1000)] decimal inflow,
        [Values(800)] decimal outflow,
        [Values(200)] decimal expected)
    {
        decimal result = _calculator.CalculateCashFlow(inflow, outflow);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateRiskAdjustedReturn(
        [Values(0.1)] decimal returnRate,
        [Values(0.02)] decimal riskFreeRate,
        [Values(1.5)] decimal beta,
        [Values(0.0533)] decimal expected)
    {
        decimal result = _calculator.CalculateRiskAdjustedReturn(returnRate, riskFreeRate, beta);
        Assert.AreEqual(expected, Math.Round(result, 4));
    }

    [Test, Sequential]
    public void Test_CalculateReturnOnInvestment(
        [Values(1500)] decimal gain,
        [Values(1000)] decimal cost,
        [Values(50.0)] decimal expected)
    {
        decimal result = _calculator.CalculateReturnOnInvestment(gain, cost);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }

    [Test, Sequential]
    public void Test_CalculateWACC(
        [Values(50000)] decimal equity,
        [Values(20000)] decimal debt,
        [Values(0.1)] decimal costEquity,
        [Values(0.05)] decimal costDebt,
        [Values(0.3)] decimal taxRate,
        [Values(0.081)] decimal expected)
    {
        decimal result = _calculator.CalculateWACC(equity, debt, costEquity, costDebt, taxRate);
        Assert.AreEqual(expected, Math.Round(result, 3));
    }

    [Test, Sequential]
    public void Test_CalculateBreakEvenPoint(
        [Values(1000)] decimal fixedCosts,
        [Values(50)] decimal pricePerUnit,
        [Values(30)] decimal variableCostPerUnit,
        [Values(50)] decimal expected)
    {
        decimal result = _calculator.CalculateBreakEvenPoint(fixedCosts, pricePerUnit, variableCostPerUnit);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateEVA(
        [Values(5000)] decimal netOperatingProfit,
        [Values(20000)] decimal capitalEmployed,
        [Values(0.1)] decimal costOfCapital,
        [Values(3000)] decimal expected)
    {
        decimal result = _calculator.CalculateEVA(netOperatingProfit, capitalEmployed, costOfCapital);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateSharpeRatio(
        [Values(0.12)] decimal portfolioReturn,
        [Values(0.03)] decimal riskFreeRate,
        [Values(0.2)] decimal portfolioRisk,
        [Values(0.45)] decimal expected)
    {
        decimal result = _calculator.CalculateSharpeRatio(portfolioReturn, riskFreeRate, portfolioRisk);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }

    [Test, Sequential]
    public void Test_CalculateProfitMargin(
        [Values(3000)] decimal netIncome,
        [Values(10000)] decimal revenue,
        [Values(30.0)] decimal expected)
    {
        decimal result = _calculator.CalculateProfitMargin(netIncome, revenue);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateCAPM(
        [Values(0.03)] decimal riskFreeRate,
        [Values(1.2)] decimal beta,
        [Values(0.1)] decimal marketReturn,
        [Values(0.114)] decimal expected)
    {
        decimal result = _calculator.CalculateCAPM(riskFreeRate, beta, marketReturn);
        Assert.AreEqual(expected, Math.Round(result, 3));
    }

    [Test, Sequential]
    public void Test_CalculateInventoryTurnoverRatio(
        [Values(20000)] decimal costOfGoodsSold,
        [Values(5000)] decimal averageInventory,
        [Values(4.0)] decimal expected)
    {
        decimal result = _calculator.CalculateInventoryTurnoverRatio(costOfGoodsSold, averageInventory);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateCurrentRatio(
        [Values(30000)] decimal currentAssets,
        [Values(15000)] decimal currentLiabilities,
        [Values(2.0)] decimal expected)
    {
        decimal result = _calculator.CalculateCurrentRatio(currentAssets, currentLiabilities);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateQuickRatio(
        [Values(30000)] decimal currentAssets,
        [Values(5000)] decimal inventories,
        [Values(15000)] decimal currentLiabilities,
        [Values(1.67)] decimal expected)
    {
        decimal result = _calculator.CalculateQuickRatio(currentAssets, inventories, currentLiabilities);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }

    [Test, Sequential]
    public void Test_CalculateReturnOnEquity(
        [Values(10000)] decimal netIncome,
        [Values(50000)] decimal shareholderEquity,
        [Values(20.0)] decimal expected)
    {
        decimal result = _calculator.CalculateReturnOnEquity(netIncome, shareholderEquity);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateLeverageRatio(
        [Values(20000)] decimal totalDebt,
        [Values(100000)] decimal totalAssets,
        [Values(0.2)] decimal expected)
    {
        decimal result = _calculator.CalculateLeverageRatio(totalDebt, totalAssets);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateGrossProfitMargin(
        [Values(3000)] decimal grossProfit,
        [Values(10000)] decimal revenue,
        [Values(30.0)] decimal expected)
    {
        decimal result = _calculator.CalculateGrossProfitMargin(grossProfit, revenue);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateYieldToMaturity(
        [Values(1000)] decimal couponPayment,
        [Values(1000)] decimal faceValue,
        [Values(900)] decimal marketPrice,
        [Values(5)] int yearsToMaturity,
        [Values(1.0737)] decimal expected)
    {
        decimal result = _calculator.CalculateYieldToMaturity(couponPayment, faceValue, marketPrice, yearsToMaturity);
        Assert.AreEqual(expected, Math.Round(result, 4));
    }

    [Test, Sequential]
    public void Test_CalculateExpenseRatio(
        [Values(500)] decimal totalExpenses,
        [Values(10000)] decimal totalAssets,
        [Values(5.0)] decimal expected)
    {
        decimal result = _calculator.CalculateExpenseRatio(totalExpenses, totalAssets);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculatePriceToEarningsRatio(
        [Values(100)] decimal marketPricePerShare,
        [Values(5)] decimal earningsPerShare,
        [Values(20.0)] decimal expected)
    {
        decimal result = _calculator.CalculatePriceToEarningsRatio(marketPricePerShare, earningsPerShare);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateEffectiveAnnualRate(
        [Values(0.05)] decimal nominalRate,
        [Values(12)] int compoundingPeriods,
        [Values(0.0512)] decimal expected)
    {
        decimal result = _calculator.CalculateEffectiveAnnualRate(nominalRate, compoundingPeriods);
        Assert.AreEqual(expected, Math.Round(result, 4));
    }

    [Test, Sequential]
    public void Test_CalculateAnnualPercentageRate(
        [Values(100)] decimal totalFees,
        [Values(10000)] decimal loanAmount,
        [Values(12)] int loanTerm,
        [Values(0.05)] decimal interestRate,
        [Values(50.0)] decimal expected)
    {
        decimal result = _calculator.CalculateAnnualPercentageRate(totalFees, loanAmount, loanTerm, interestRate);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }

    [Test, Sequential]
    public void Test_CalculateReturnOnAssets(
        [Values(2000)] decimal netIncome,
        [Values(10000)] decimal totalAssets,
        [Values(20.0)] decimal expected)
    {
        decimal result = _calculator.CalculateReturnOnAssets(netIncome, totalAssets);
        Assert.AreEqual(expected, result);
    }

    [Test, Sequential]
    public void Test_CalculateTimeWeightedRateOfReturn(
        [Values(0.1)] decimal return1,
        [Values(0.2)] decimal return2,
        [Values(-0.1)] decimal return3,
        [Values(0.188)] decimal expected)
    {
        decimal[] returns = { return1, return2, return3 };
        decimal result = _calculator.CalculateTimeWeightedRateOfReturn(returns);
        Assert.AreEqual(expected, Math.Round(result, 4));
    }

    [Test, Sequential]
    public void Test_CalculateModifiedDuration(
        [Values(1000)] decimal price,
        [Values(0.05)] decimal yield,
        [Values(5)] int years,
        [Values(783.53)] decimal expected)
    {
        decimal result = _calculator.CalculateModifiedDuration(price, yield, years);
        Assert.AreEqual(expected, Math.Round(result, 2));
    }
}
