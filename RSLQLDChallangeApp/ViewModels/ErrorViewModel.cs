using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//The ErrorViewModel is used to display error messages and other relevant information on the Error page

namespace RSLQLDChallangeApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}