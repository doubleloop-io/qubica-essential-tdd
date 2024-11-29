namespace _06_ProfitCalculatorKata;

class ProfitCalculator
{
    static readonly IReadOnlyDictionary<string, decimal> ExchangeRates = new Dictionary<string, decimal>
    {
        { "GBP", 1.0M },
        { "USD", 1.6M },
        { "EUR", 1.2M },
    };

    private string localCurrency;
    private decimal localAmount = 0;
    private decimal foreignAmount = 0;

    public ProfitCalculator(string localCurrency)
    {
        this.localCurrency = localCurrency;

        if (ExchangeRates[localCurrency] == 0)
        {
            throw new Exception("Invalid currency '${localCurrency}'");
        }
    }

    public void Add(decimal amount, string currency, bool incoming)
    {
        var realAmount = amount;

        if (ExchangeRates[currency] == 0)
        {
            throw new Exception("Invalid currency '${currency}'");
        }

        var exchangeRate =
            (ExchangeRates[currency]) /
            (ExchangeRates[this.localCurrency]);

        realAmount = Math.Floor(realAmount / exchangeRate);

        if (!incoming)
        {
            realAmount = -realAmount;
        }

        if (this.localCurrency == currency)
        {
            this.localAmount += realAmount;
        }
        else
        {
            this.foreignAmount += realAmount;
        }
    }

    public decimal CalculateProfit()
    {
        return this.localAmount - this.CalculateTax() + this.foreignAmount;
    }

    public decimal CalculateTax()
    {
        if (this.localAmount < 0)
        {
            return 0;
        }

        return Math.Floor(this.localAmount * 0.2M);
    }
}