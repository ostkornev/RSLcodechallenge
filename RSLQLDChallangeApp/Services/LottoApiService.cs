using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RSLQLDChallangeApp.Models;

// The LottoApiService class is responsible for making requests to the API endpoint that provides information on the open lotteries and their draws.

namespace RSLQLDChallangeApp.Services
{
    public class LottoApiService
    {
        private readonly HttpClient _httpClient;
        //set the base URL
        private const string BaseUrl = "https://data.api.thelott.com/sales/vmax/web/data/lotto/";

        public LottoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // The GetOpenLotteriesDrawsAsync method takes three arguments:
        // 1. A string companyId that specifies the company whose lottery draws are to be retrieved.
        // 2. An int maxDrawCount that specifies the maximum number of draws to retrieve.
        // 3. A string[] optionalProductFilter that specifies an optional filter to limit the types of lottery draws that are retrieved.

        public async Task<LottoApiResponse> GetOpenLotteriesDrawsAsync(string companyId, int maxDrawCount, string[] optionalProductFilter)
        {
            var requestUrl = $"{BaseUrl}opendraws";
            var requestData = new
            {
                CompanyId = companyId,
                MaxDrawCount = maxDrawCount,
                OptionalProductFilter = optionalProductFilter
            };

            var jsonContent = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                // send a POST request to the API endpoint with the specified arguments as request data.
                var response = await _httpClient.PostAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var lottoApiResponse = JsonSerializer.Deserialize<LottoApiResponse>(responseBody);

                return lottoApiResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return new LottoApiResponse
                {
                    Success = false,
                    ErrorInfo = new ErrorInfo
                    {
                        DisplayMessage = ex.Message
                    }
                };
            }
        }
    }
}



