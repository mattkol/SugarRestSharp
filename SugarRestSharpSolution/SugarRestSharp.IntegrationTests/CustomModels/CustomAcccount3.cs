using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarRestSharp.IntegrationTests.CustomModels
{
    using Newtonsoft.Json;
    using SugarRestSharp.Models;
    using System.Collections.Generic;

    public class CustomAcccount3 : Account
    {
        [JsonProperty(PropertyName = "Bugs")]
        public virtual List<Bug> ContactLink { get; set; }

        [JsonProperty(PropertyName = "cases")]
        public virtual List<Case> CaseLink { get; set; }
    }
}
