using InsertNbp.Commands.Services;
using InsertNbp.NbpApi;

namespace InsertNbp.Tests
{
    public class Tests
    {
        NbpService _nbpService;


        [SetUp]
        public void Setup()
        {
            _nbpService = new NbpService();

        }

        [Test]
        public void Test1()
        {
            var rates = _nbpService.GetRatesAsync().Result;
            Assert.That(rates.Any());
        }

        [Test]
        public void Test2()
        {
            var rates = _nbpService.GetMidExchangeRatesAsync().Result;
            Assert.That(rates.Any());
        }

        [Test]
        public void Test3()
        {
            var rates = _nbpService.GetBuyAndSellRatesAsync().Result;
            Assert.That(rates.Rates.Any());
        }
    }
}