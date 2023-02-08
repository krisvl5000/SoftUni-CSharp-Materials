using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class Investor
    {
        private readonly List<Stock> portfolio;

        public Investor(string fullName, string emailAddress,
            decimal moneytoInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneytoInvest;
            BrokerName = brokerName;

            portfolio = new List<Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public List<Stock> Portfolio { get { return portfolio; } }

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && 
                MoneyToInvest >= stock.PricePerShare)
            {
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stockToSell = portfolio
                .FirstOrDefault(x => x.CompanyName == companyName);

            if (stockToSell == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stockToSell.PricePerShare)
            {
                return $"Cannot sell {companyName}";
            }

            portfolio.Remove(stockToSell);
            MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return portfolio
                .OrderByDescending(x => x.MarketCapitalization)
                .FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} " +
                $"has stocks:");

            foreach (var item in portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
