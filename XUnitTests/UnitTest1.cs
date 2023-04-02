using System;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using RSLQLDChallangeApp.Services;

namespace XUnitTests
{
    public class UnitTest1
    {
        private readonly LottoApiService _lottoApiService;

        public UnitTest1()
        {
            // Create an instance of LottoApiService using a HttpClient instance
            var httpClient = new HttpClient();
            _lottoApiService = new LottoApiService(httpClient);
        }

        //The following tests help to ensure that the GetOpenLotteriesDrawsAsync method in the LottoApiService class is working as expected.

        [Fact]
        public async Task GetOpenLotteriesDrawsAsync_ReturnsNotNull()
        {
            // Act
            var result = await _lottoApiService.GetOpenLotteriesDrawsAsync("Tattersalls", 10, null);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetOpenLotteriesDrawsAsync_ReturnsSuccessTrue()
        {
            // Act
            var result = await _lottoApiService.GetOpenLotteriesDrawsAsync("Tattersalls", 10, null);

            // Assert
            Assert.True(result.Success);
        }
    }
}
