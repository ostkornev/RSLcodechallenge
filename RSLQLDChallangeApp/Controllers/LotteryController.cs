using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RSLQLDChallangeApp.Services;
using RSLQLDChallangeApp.ViewModels;

//The LotteryController class is a controller for the Index view that retrieves and filters data from the Lotto API.

namespace RSLQLDChallangeApp.Controllers
{
    public class LotteryController : Controller
    {
        private readonly LottoApiService _lottoApiService;

        public LotteryController(LottoApiService lottoApiService)
        {
            _lottoApiService = lottoApiService;
        }

        //Index method uses the LottoApiService to retrieve data from the Lotto API by calling the GetOpenLotteriesDrawsAsync method
        public async Task<IActionResult> Index()
        {
            var companyId = "Tattersalls";
            var maxDrawCount = 10;
            var optionalProductFilter = new[] { "OzLotto", "TattsLotto", "Powerball" };

            var lottoApiResponse = await _lottoApiService.GetOpenLotteriesDrawsAsync(companyId, maxDrawCount, optionalProductFilter);

            if (!lottoApiResponse.Success || lottoApiResponse.Draws == null)
            {
                return View("Error");
            }

            var filteredDraws = lottoApiResponse.Draws
                .Where(draw => optionalProductFilter.Contains(draw.ProductId))
                .ToList();

            //The LotteryViewModel is used to display data in the Index view.
            var viewModel = new LotteryViewModel
            {
                Draws = filteredDraws
            };

            return View(viewModel);
        }
    }
}
