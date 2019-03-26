
namespace EuroToReal {

    public static class Configuration {

        public static string BotToken = "622182154:AAEc1s0LzV8ItlLwclpnD5cGOMmH16NpziM";

        public static int NumberOfButtons { get; } = 7;

        public static string Page { get; } = "https://www.bportugal.pt/taxas-cambio";

        public static string Xpath { get; } = "//*[@id='rates-front']/*[@class='rates-row']/*[@class='rates-coin'][contains(string(), '@coin')]/../*[@class='rates-@item']";

        public enum Currency {
            AED, AFN, ANG, AOA,
            ARS, AUD, BGN, BHD,
            BMD, BOB, BRL, BSD,
            BWP, BYN, CAD, CDF,
            CHF, CLP, CNY, COP,
            CRC, CUP, CVE, CZK,
            DKK, DOP, DZD, EEK,
            EGP, ETB, EUR, GBP,
            GHS, GIP, GNF, GTQ,
            GYD, HKD, HNL, HRK,
            HTG, HUF, IDR, ILS,
            INR, IQD, IRR, ISK,
            JMD, JOD, JPY, KES,
            KPW, KRW, KWD, KZT,
            LBP, LKR, LRD, LTL,
            LVL, LYD, MAD, MGA,
            MMK, MOP, MRO, MRU,
            MUR, MWK, MXN, MYR,
            MZN, NAD, NGN, NIO,
            NOK, NZD, OMR, PAB,
            PEN, PHP, PKR, PLN,
            PYG, QAR, RON, RSD,
            RUB, SAR, SDG, SEK,
            SGD, SLL, SOS, SRD,
            STD, STN, SVC, SYP,
            SZL, THB, TND, TRY,
            TTD, TWD, TZS, UAH,
            UGX, USD, UYU, VND,
            XAF, XOF, YER, ZAR,
            ZMW, ZWL
        };
    }        
}