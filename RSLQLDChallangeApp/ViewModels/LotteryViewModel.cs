using System.Collections.Generic;
using RSLQLDChallangeApp.Models;

//This view model is intended to be used to pass data from the controller to the view 

namespace RSLQLDChallangeApp.ViewModels
{
    public class LotteryViewModel
    {
        public List<Draw> Draws { get; set; }
    }
}