namespace EuroToReal {

    public class Exchange {

        private Scrapper scrapper;

        public Exchange() {
            this.scrapper = new Scrapper();
        }

        public string GetRate(string coin) {

            string xpathRate = Configuration.Xpath.Replace("@coin", coin).Replace("@item", "rate");
            string xpathDate = Configuration.Xpath.Replace("@coin", coin).Replace("@item", "date");

            string rate = scrapper.Get(Configuration.Page, xpathRate);
            string date = scrapper.Get(Configuration.Page, xpathDate);

            string text = $"1 Euro value in {coin} is {rate} at {date}";

            return text;
        }
    }
}