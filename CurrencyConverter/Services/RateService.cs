using System;

namespace CurrencyConverter.Services
{
    public interface IRateService
    {
        double GetExchangeRate(string to, string from);
        double Convert(string to, string from, double amount);
        double Sum(string currency1, double amount1, string currency2, double amount2, string currencyResult);
    }

    public class RateService : IRateService
    {
        public const string USD = "USD";
        private readonly RatesConfig _rates;
        public RateService(RatesConfig rates)
        {
            _rates = rates;
        }

        private double GetRateFromUSD(string currency)
        {
            if (currency == USD)
                return 1;
            else
            {
                if (!_rates.ContainsKey(currency))
                {
                    throw new ArgumentException($"No rate data for {currency}");
                }
                return _rates[currency];
            }
        }

        public double GetExchangeRate(string to, string from)
        {
            // First Get the exchange rate of both currencies in USD
            double toRate = GetRateFromUSD(to);
            double fromRate = GetRateFromUSD(from);

            // Convert Between USD to Other Currency
            if (from == USD)
            {
                return toRate;
            }
            else if (to == USD)
            {
                return 1 / fromRate;
            }
            else
            {
                // Calculate non USD exchange rates From A to B
                return toRate / fromRate;
            }
        }

        public double Convert(string to, string from, double amount)
        {
            var rate = GetExchangeRate(to, from);

            return (double)Math.Round(amount * rate, 2);
        }
        public double Sum(string currency1, double amount1, string currency2, double amount2, string currencyResult)
        {
            var value1 = GetExchangeRate(currencyResult, currency1) * amount1;
            var value2 = GetExchangeRate(currencyResult, currency2) * amount2;

            var rounded = Math.Round(value1 + value2, 2);
            return rounded;
        }
    }
}
