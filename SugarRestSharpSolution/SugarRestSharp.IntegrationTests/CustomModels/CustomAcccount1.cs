namespace SugarRestSharp.IntegrationTests.CustomModels
{
    using Newtonsoft.Json;
    using SugarRestSharp.Models;
    using System.Collections.Generic;

    public class CustomAcccount1 : Account
    {
        [JsonProperty(PropertyName = "contacts")]
        public virtual List<Contact> ContactLink { get; set; }
    }
}
