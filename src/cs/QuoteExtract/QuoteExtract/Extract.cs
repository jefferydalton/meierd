using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace QuoteExtract
{
    public static class Extract
    {

        public static List<Quote> PullQuotes(string siteUrl)
        {
            Ensure.That(siteUrl).IsNotNullOrWhiteSpace();
                        
            return MapQuotes(new HtmlWeb().Load(siteUrl)?.DocumentNode.SelectSingleNode("//h2"));
        }

        private static List<Quote> MapQuotes(HtmlNode node)
        {
            var jdMeirerQuoteRx = new Regex(@"(“.+”)\s(—|–)\s(.+)");
            var result = new List<Quote>();
            var category = "";
            HtmlNode currentNode = node;

            while (currentNode != null)
            {
                switch (currentNode.Name)
                {
                    case "h2":
                        category = HtmlEntity.DeEntitize(currentNode.InnerText);
                        break;
                    case "p":
                        var quote = MapQuote(currentNode, category, jdMeirerQuoteRx);
                        if (quote != null)
                        {
                            result.Add(quote);
                            currentNode = currentNode.NextSibling;
                        }
                        break;
                    default:
                        break;
                }
                currentNode = currentNode.NextSibling;
            }

            return result;
        }

        private static Quote MapQuote(HtmlNode pTag, string category, Regex quoteRegEx)
        {
            var matchedResults = quoteRegEx.Match(HtmlEntity.DeEntitize(pTag.InnerText) + " " + HtmlEntity.DeEntitize(pTag.NextSibling?.InnerText));
            if (matchedResults.Success)
                return new Quote { Category = category, QuoteText = matchedResults.Groups[1].Value, Author = matchedResults.Groups[3].Value };

            return null;
        }
    }
}
