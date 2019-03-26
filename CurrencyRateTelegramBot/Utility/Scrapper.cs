
namespace EuroToReal {

    public class Scrapper {

        public string Get(string page, string xpath) {

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = web.Load(page);

            string value = htmlDocument.DocumentNode.SelectSingleNode(xpath).InnerText;

            return value;
        }
    }
}