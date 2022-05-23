using InsertNbp.NbpApi.Interfaces;
using InsertNbp.NbpApi.Models;
using InsertNbp.NbpApi.Models.Responses;
using Newtonsoft.Json;

namespace InsertNbp.NbpApi
{
    public enum MidExchangeRateTables
    {
        A,
        B
    } 

    public class NbpService
    {
        private readonly HttpClient _httpClient;
        public NbpService()
        {
            _httpClient = new();
            var mt = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(mt);
        }
        private enum RateTables
        {
            A,
            B,
            C
        }

        /// <summary>
        /// Pobiera średnie kursy walut z NBP oraz kursy kupna i sprzedaży
        /// </summary>
        /// <param name="date">Zostawienie nulla spowoduje pobranie danych na dzień dzisiejszy</param>
        /// <returns></returns>
        public async Task<List<Rate>> GetRatesAsync(DateTime? date = null)
        {
            
            Response<BuyAndSellRate> tableC = await GetBuyAndSellRatesAsync(date);

            List<MidExchangeRate> midExchangeRates = await GetMidExchangeRatesAsync(date);

            List<Rate> result = (from midRate in midExchangeRates
                                 join bsRate in tableC.Rates on midRate.Currency equals bsRate.Currency into gBsRate
                                 from buySellRate in gBsRate.DefaultIfEmpty()
                                 select new Rate
                                 {
                                     Currency = midRate.Currency,
                                     Ask = buySellRate?.Ask,
                                     Bid = buySellRate?.Bid,
                                     Code = midRate.Code,
                                     Mid = midRate.Mid
                                 }).DistinctBy(x => x.Code).ToList();
            return result;
        }

        /// <summary>
        /// Pobiera średnie kursy walut z NBP ze wszystkich tabel kursów średnich (A i B)
        /// </summary>
        /// <param name="date">Zostawienie nulla spowoduje pobranie danych na dzień dzisiejszy</param>
        /// <returns></returns>
        public async Task<List<MidExchangeRate>> GetMidExchangeRatesAsync(DateTime? date = null)
        {
            Response<MidExchangeRate> tableA = await GetMidExchangeRatesAsync<MidExchangeRate>(MidExchangeRateTables.A, date);
            Response<MidExchangeRate> tableB = await GetMidExchangeRatesAsync<MidExchangeRate>(MidExchangeRateTables.B, date);
            return (tableA.Rates).Concat(tableB.Rates).ToList();
        }

        /// <summary>
        /// Pobiera średnie kursy walut z NBP, z wybranej tabeli
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">Wybór tabeli: A albo B</param>
        /// <param name="date">Zostawienie nulla spowoduje pobranie danych na dzień dzisiejszy</param>
        /// <returns></returns>
        public async Task<Response<T>> GetMidExchangeRatesAsync<T>(MidExchangeRateTables table, DateTime? date = null) where T : CurrencyRateBase, IRateForTablesAB
        {
            return await UseNbpApi<T>((RateTables)table, date);
        }

        /// <summary>
        /// Pobranie kursów kupna i sprzedaży kursów walut z NBP
        /// </summary>
        /// <param name="date">Zostawienie null spowoduje pobranie danych na dzień dzisiejszy</param>
        /// <returns></returns>
        public async Task<Response<BuyAndSellRate>> GetBuyAndSellRatesAsync(DateTime? date = null)
        {
            return await UseNbpApi<BuyAndSellRate>(RateTables.C, date);
            
        }

        /// <summary>
        /// Pobiera dane z NBP za pomocą REST API
        /// </summary>
        /// <param name="table">A lub b lub c</param>
        /// <param name="endDate">Domyslnie zostanie pobrany stan na dzień dzisiejszy</param>
        /// <param name="fromDate">Domyślnie date.AddDays(-7)</param>
        /// <returns></returns>
        private async Task<Response<T>> UseNbpApi<T>(RateTables table, DateTime? endDate = null, DateTime? fromDate = null) where T : CurrencyRateBase
        {
            ArgumentNullException.ThrowIfNull(table, nameof(table));
            const string urlBase = @"http://api.nbp.pl/api/exchangerates/tables/";
            string content;
            endDate ??= DateTime.Now;
            fromDate ??= endDate.Value.AddDays(-7);
            HttpRequestMessage requestMessage = new(HttpMethod.Get, $@"{urlBase}{table}/{fromDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}");
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
            if (responseMessage.IsSuccessStatusCode)
            {
                content = await responseMessage.Content.ReadAsStringAsync();
                List<Response<T>> responses = JsonConvert.DeserializeObject<List<Response<T>>>(content);
                return responses.LastOrDefault();
            }
            else
            {
                content = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"{responseMessage.StatusCode}: {content}");
            }
        }
    }
}