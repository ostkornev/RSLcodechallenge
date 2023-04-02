namespace RSLQLDChallangeApp.Models
{
    public class ErrorInfo
    {
        public int SystemId { get; set; }
        public int ErrorNo { get; set; }
        public string DisplayMessage { get; set; }
        public bool ContactSupport { get; set; }
        public string SupportErrorReference { get; set; }
    }
}