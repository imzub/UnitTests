using System;

public class FinancialCalculator
{
    // 1. Calculate Compound Interest
    public decimal CalculateCompoundInterest(decimal principal, decimal rate, int time, int frequency)
    {
        return Math.Round(principal * (decimal)Math.Pow((double)(1 + rate / frequency), frequency * time), 2);
    }

    // 2. Calculate Future Value of Annuity
    public decimal CalculateFutureValueOfAnnuity(decimal payment, decimal rate, int periods)
    {
        return Math.Round(payment * (((decimal)Math.Pow((double)(1 + rate), periods) - 1) / rate), 2);
    }

    // 3. Calculate Present Value of Annuity
    public decimal CalculatePresentValueOfAnnuity(decimal payment, decimal rate, int periods)
    {
        return Math.Round(payment * ((1 - (decimal)Math.Pow((double)(1 + rate), -periods)) / rate), 2);
    }

    // 4. Calculate Net Present Value
    public decimal CalculateNetPresentValue(decimal[] cashFlows, decimal discountRate)
    {
        decimal npv = 0;
        for (int i = 0; i < cashFlows.Length; i++)
        {
            npv += cashFlows[i] / (decimal)Math.Pow(1 + (double)discountRate, i);
        }
        return Math.Round(npv, 2);
    }

    // 5. Calculate Internal Rate of Return
    public decimal CalculateInternalRateOfReturn(decimal[] cashFlows)
    {
        decimal irr = 0.1m; // Initial guess
        for (int i = 0; i < 100; i++) // Simple iteration
        {
            irr -= CalculateNetPresentValue(cashFlows, irr) / 100; // Adjust based on NPV
        }
        return Math.Round(irr, 4);
    }

    // 6. Calculate Loan Amortization
    public decimal CalculateLoanAmortization(decimal principal, decimal rate, int periods)
    {
        decimal monthlyRate = rate / 12;
        return Math.Round((principal * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -periods)), 2);
    }

    // 7. Calculate Debt to Income Ratio
    public decimal CalculateDebtToIncomeRatio(decimal totalDebt, decimal totalIncome)
    {
        return Math.Round((totalDebt / totalIncome) * 100, 2);
    }

    // 8. Calculate Cash Flow
    public decimal CalculateCashFlow(decimal inflow, decimal outflow)
    {
        return Math.Round(inflow - outflow, 2);
    }

    // 9. Calculate Risk Adjusted Return
    public decimal CalculateRiskAdjustedReturn(decimal returnRate, decimal riskFreeRate, decimal beta)
    {
        return Math.Round((returnRate - riskFreeRate) / beta, 4);
    }

    // 10. Calculate Return on Investment
    public decimal CalculateReturnOnInvestment(decimal gain, decimal cost)
    {
        return Math.Round((gain - cost) / cost * 100, 2);
    }

    // 11. Calculate Weighted Average Cost of Capital
    public decimal CalculateWACC(decimal equity, decimal debt, decimal costEquity, decimal costDebt, decimal taxRate)
    {
        return Math.Round(((equity / (equity + debt)) * costEquity) + ((debt / (equity + debt)) * costDebt * (1 - taxRate)), 4);
    }

    // 12. Calculate Break Even Point
    public decimal CalculateBreakEvenPoint(decimal fixedCosts, decimal pricePerUnit, decimal variableCostPerUnit)
    {
        return Math.Round(fixedCosts / (pricePerUnit - variableCostPerUnit), 2);
    }

    // 13. Calculate Economic Value Added
    public decimal CalculateEVA(decimal netOperatingProfit, decimal capitalEmployed, decimal costOfCapital)
    {
        return Math.Round(netOperatingProfit - (capitalEmployed * costOfCapital), 2);
    }

    // 14. Calculate Sharpe Ratio
    public decimal CalculateSharpeRatio(decimal portfolioReturn, decimal riskFreeRate, decimal portfolioRisk)
    {
        return Math.Round((portfolioReturn - riskFreeRate) / portfolioRisk, 2);
    }

    // 15. Calculate Profit Margin
    public decimal CalculateProfitMargin(decimal netIncome, decimal revenue)
    {
        return Math.Round((netIncome / revenue) * 100, 2);
    }

    // 16. Calculate Capital Asset Pricing Model (CAPM)
    public decimal CalculateCAPM(decimal riskFreeRate, decimal beta, decimal marketReturn)
    {
        return Math.Round(riskFreeRate + beta * (marketReturn - riskFreeRate), 4);
    }

    // 17. Calculate Inventory Turnover Ratio
    public decimal CalculateInventoryTurnoverRatio(decimal costOfGoodsSold, decimal averageInventory)
    {
        return Math.Round(costOfGoodsSold / averageInventory, 2);
    }

    // 18. Calculate Current Ratio
    public decimal CalculateCurrentRatio(decimal currentAssets, decimal currentLiabilities)
    {
        return Math.Round(currentAssets / currentLiabilities, 2);
    }

    // 19. Calculate Quick Ratio
    public decimal CalculateQuickRatio(decimal currentAssets, decimal inventories, decimal currentLiabilities)
    {
        return Math.Round((currentAssets - inventories) / currentLiabilities, 2);
    }

    // 20. Calculate Return on Equity
    public decimal CalculateReturnOnEquity(decimal netIncome, decimal shareholderEquity)
    {
        return Math.Round((netIncome / shareholderEquity) * 100, 2);
    }

    // 21. Calculate Leverage Ratio
    public decimal CalculateLeverageRatio(decimal totalDebt, decimal totalAssets)
    {
        return Math.Round(totalDebt / totalAssets, 2);
    }

    // 22. Calculate Gross Profit Margin
    public decimal CalculateGrossProfitMargin(decimal grossProfit, decimal revenue)
    {
        return Math.Round((grossProfit / revenue) * 100, 2);
    }

    // 23. Calculate Yield to Maturity
    public decimal CalculateYieldToMaturity(decimal couponPayment, decimal faceValue, decimal marketPrice, int yearsToMaturity)
    {
        return Math.Round((couponPayment + (faceValue - marketPrice) / yearsToMaturity) / ((faceValue + marketPrice) / 2), 4);
    }

    // 24. Calculate Expense Ratio
    public decimal CalculateExpenseRatio(decimal totalExpenses, decimal totalAssets)
    {
        return Math.Round((totalExpenses / totalAssets) * 100, 2);
    }

    // 25. Calculate Price to Earnings Ratio
    public decimal CalculatePriceToEarningsRatio(decimal marketPricePerShare, decimal earningsPerShare)
    {
        return Math.Round(marketPricePerShare / earningsPerShare, 2);
    }

    // 26. Calculate Effective Annual Rate
    public decimal CalculateEffectiveAnnualRate(decimal nominalRate, int compoundingPeriods)
    {
        return Math.Round((decimal)Math.Pow((double)(1 + nominalRate / compoundingPeriods), compoundingPeriods) - 1, 4);
    }

    // 27. Calculate Annual Percentage Rate
    public decimal CalculateAnnualPercentageRate(decimal totalFees, decimal loanAmount, int loanTerm, decimal interestRate)
    {
        return Math.Round((totalFees + (loanAmount * interestRate)) / loanTerm, 2);
    }

    // 28. Calculate Return on Assets
    public decimal CalculateReturnOnAssets(decimal netIncome, decimal totalAssets)
    {
        return Math.Round((netIncome / totalAssets) * 100, 2);
    }

    // 29. Calculate Time-Weighted Rate of Return
    public decimal CalculateTimeWeightedRateOfReturn(decimal[] returns)
    {
        decimal result = 1;
        foreach (var r in returns)
        {
            result *= (1 + r);
        }
        return Math.Round(result - 1, 4);
    }

    // 30. Calculate Modified Duration
    public decimal CalculateModifiedDuration(decimal price, decimal yield, int years)
    {
        return Math.Round(price / (decimal)Math.Pow(1 + (double)yield, years), 2);
    }
}
