namespace _06_ProfitCalculatorKata;

public class ProfitCalculatorTest
{
    private ProfitCalculator gbpCalculator = new ProfitCalculator("GBP");
    private ProfitCalculator eurCalculator = new ProfitCalculator("EUR");

    [Fact]
    public void Calculates_the_tax_at_20_percent()
    {
        gbpCalculator.Add(500, "GBP", true);

        var profit = gbpCalculator.CalculateProfit();
        var tax = gbpCalculator.CalculateTax();

        Assert.Equal(400, profit);
        Assert.Equal(100, tax);
    }

    [Fact]
    public void Calculates_the_tax_of_multiple_amounts()
    {
        gbpCalculator.Add(120, "GBP", true);
        gbpCalculator.Add(200, "GBP", true);

        var profit = gbpCalculator.CalculateProfit();
        var tax = gbpCalculator.CalculateTax();

        Assert.Equal(256, profit);
        Assert.Equal(64, tax);
    }

    [Fact]
    public void Different_currencies_are_not_taxed()
    {
        gbpCalculator.Add(120, "GBP", true);
        gbpCalculator.Add(200, "USD", true);

        var profit = gbpCalculator.CalculateProfit();
        var tax = gbpCalculator.CalculateTax();

        Assert.Equal(221, profit);
        Assert.Equal(24, tax);
    }

    [Fact]
    public void Handle_outgoings()
    {
        gbpCalculator.Add(500, "GBP", true);
        gbpCalculator.Add(80, "USD", true);
        gbpCalculator.Add(360, "EUR", false);

        var profit = gbpCalculator.CalculateProfit();
        var tax = gbpCalculator.CalculateTax();

        Assert.Equal(150, profit);
        Assert.Equal(100, tax);
    }

    [Fact]
    public void A_negative_balance_results_in_no_tax()
    {
        gbpCalculator.Add(500, "GBP", true);
        gbpCalculator.Add(200, "GBP", false);
        gbpCalculator.Add(400, "GBP", false);
        gbpCalculator.Add(20, "GBP", false);

        var profit = gbpCalculator.CalculateProfit();
        var tax = gbpCalculator.CalculateTax();

        Assert.Equal(-120, profit);
        Assert.Equal(0, tax);
    }

    [Fact]
    public void Everything_is_reported_in_the_local_currency()
    {
        eurCalculator.Add(400, "GBP", true);
        eurCalculator.Add(200, "USD", false);
        eurCalculator.Add(200, "EUR", true);

        var profit = eurCalculator.CalculateProfit();
        var tax = eurCalculator.CalculateTax();

        Assert.Equal(490, profit);
        Assert.Equal(40, tax);
    }
}