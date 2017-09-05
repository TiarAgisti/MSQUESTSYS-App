using MQUESTSYS.DA;
using MQUESTSYS.Models.Master;
using System;

namespace MQUESTSYS.Helpers
{
    public class RateHelper
    {

        //public void RetrieveRatesFromExcel(string fromCurrency)
        //{
        //    try
        //    {
        //        //string fromCurrency = "USD";
        //        const string toCurrency = "IDR";
        //        const double amount = 1;

        //        // Construct URL to query the Yahoo! Finance API
        //        const string urlPattern = "http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1";
        //        string url = String.Format(urlPattern, fromCurrency, toCurrency);
        //        string response = new System.Net.WebClient().DownloadString(url);
        //        double exchangeRate = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);

        //        RateModel rate = new MQUESTSYSDAC().RetrieveRates(fromCurrency);
        //        rate.Value = Convert.ToDecimal(exchangeRate);
        //        new MQUESTSYSDAC().UpdateRate(rate);
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}

        //public void RetrieveRatesFromExcel()
        //{
        //    try
        //    {
        //        string fromCurrency = "EUR";
        //        const string toCurrency = "IDR";

        //        // Construct URL to query the Yahoo! Finance API
        //        const string urlPattern = "http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1";
        //        string url = String.Format(urlPattern, fromCurrency, toCurrency);
        //        string response = new System.Net.WebClient().DownloadString(url);
        //        double exchangeRate = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);

        //        RateModel rate = new MQUESTSYSDAC().RetrieveRates(fromCurrency);
        //        rate.Value = Convert.ToDecimal(exchangeRate);
        //        new MQUESTSYSDAC().UpdateRate(rate);

        //        fromCurrency = "USD";
        //        url = String.Format(urlPattern, fromCurrency, toCurrency);
        //        response = new System.Net.WebClient().DownloadString(url);
        //        exchangeRate = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);

        //        RateModel rate2 = new MQUESTSYSDAC().RetrieveRates(fromCurrency);
        //        rate2.Value = Convert.ToDecimal(exchangeRate);
        //        new MQUESTSYSDAC().UpdateRate(rate2);

        //        fromCurrency = "SGD";
        //        url = String.Format(urlPattern, fromCurrency, toCurrency);
        //        response = new System.Net.WebClient().DownloadString(url);
        //        exchangeRate = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);

        //        RateModel rate3 = new MQUESTSYSDAC().RetrieveRates(fromCurrency);
        //        rate3.Value = Convert.ToDecimal(exchangeRate);
        //        new MQUESTSYSDAC().UpdateRate(rate3);
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}