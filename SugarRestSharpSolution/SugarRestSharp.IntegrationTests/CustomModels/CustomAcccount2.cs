namespace SugarRestSharp.IntegrationTests.CustomModels
{
    using Newtonsoft.Json;
    using SugarRestSharp.Models;
    using System.Collections.Generic;

    public class CustomAcccount2 : Account
    {
        [JsonProperty(PropertyName = "contacts")]
        public virtual List<Contact> ContactLink { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public virtual List<Lead> LeadLink { get; set; }

        [JsonProperty(PropertyName = "cases")]
        public virtual List<Case> CaseLink { get; set; }
    }
}
