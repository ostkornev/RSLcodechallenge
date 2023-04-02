using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//defines the data model for the Lotto API response

namespace RSLQLDChallangeApp.Models
{
 
    public class LottoApiResponse
    {
        public List<Draw> Draws { get; set; } = new List<Draw>();
        public object ErrorInfo { get; set; }
        public bool Success { get; set; }
    }

    // Product class represents a lottery product and contains information such as the product ID, display name, logo URL, and latest draw.
    public class Product
    {
        public string ProductId { get; set; }
        public string DisplayName { get; set; }
        public string LogoUrl { get; set; }
        public Draw LatestDraw { get; set; }
    }

    //The Draw class represents a lottery draw and contains information about it
    public class Draw
    {
        public string ProductId { get; set; }
        public int DrawNumber { get; set; }
        public string DrawDisplayName { get; set; }
        public DateTime DrawDate { get; set; }
        public string DrawLogoUrl { get; set; }
        public string DrawType { get; set; }
        public decimal Div1Amount { get; set; }
        public bool IsDiv1Estimated { get; set; }
        public bool IsDiv1Unknown { get; set; }
        public DateTime DrawCloseDateTimeUTC { get; set; }
        public DateTime DrawEndSellDateTimeUTC { get; set; }
        public double DrawCountDownTimerSeconds { get; set; }
    }
}
