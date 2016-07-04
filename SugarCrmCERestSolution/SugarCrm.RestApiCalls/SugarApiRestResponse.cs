using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace SugarCrm.RestApiCalls
{
    public class SugarApiRestResponse
    {
        public IRestResponse RestResponse { get; set; }
        public string JsonRawRequest { get; set; }
        public string JsonRawResponse { get; set; }
    }
}
