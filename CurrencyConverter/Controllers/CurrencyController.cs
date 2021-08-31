using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using CurrencyConverter.Services;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IRateService _rateService;

        public CurrencyController(ILogger<CurrencyController> logger, IRateService rateService)
        {
            _logger = logger;
            _rateService = rateService;
        }

        [HttpGet("rate/{to}")]
        public double Rate(string to)
        {
            return Rate(to, RateService.USD);
        }

        [HttpGet("rate/{to}/{from}")]
        public double Rate(string to, string from)
        {
            try
            {
                return _rateService.GetExchangeRate(to.ToUpper(), from.ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
                throw;
            }
        }

        [HttpGet("convert/{to}/{from}/{amount}")]
        public double Convert(string to, string from, double amount)
        {
            try
            {
                return (double)Math.Round(_rateService.Convert(to.ToUpper(), from.ToUpper(), amount), 2);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
                throw;
            }
        }

        [HttpGet("sum/{currency1}/{amount1}/{currency2}/{amount2}/{currencyResult}")]
        public double Sum(string currency1, double amount1, string currency2, double amount2, string currencyResult)
        {
            try
            {
                return _rateService.Sum(currency1.ToUpper(), amount1, currency2.ToUpper(),amount2, currencyResult.ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
                throw;
            }
        }
    }
}
