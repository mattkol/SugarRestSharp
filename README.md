# Being RESTful with SugarCRM in .NET C# 
SugarRestSharp is a .NET C# SugarCRM CE 6.5 API client. SugarCRM RestSharp is a RestSharp implementation. It is a Restful CRUD client that implements the SugarCRM module Create, Read, Update and Delete functionalities.

SugarRestSharp implements following SugarCRM REST API method calls: **_oauth_access, get_entry, get_entry_list, set_entry, set_entries._**

SugarRestSharp is available on [Nuget](https://www.nuget.org/packages/SugarRestSharp/1.0.0).

For more info/documentation, please check [SugarRestSharp wiki](https://github.com/mattkol/SugarRestSharp/wiki)

### Basic Sample Usages
```cs
            string sugarCrmUrl = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string sugarCrmUsername = "will";
            string sugarCrmPassword = "will";

            var client = new SugarRestClient(sugarCrmUrl, sugarCrmUsername, sugarCrmPassword);

            // Option 1 - Read by known type typeof(Account).
            var accountRequest = new SugarRestRequest(RequestType.ReadById);
            
            // set the account id to read.
            accountRequest.Id = "1f2d3240-0d8a-ca09-2e11-5777c29a4193";
            SugarRestResponse accountResponse = client.Execute<Account>(accountRequest);
            Account account = (Account)accountResponse.Data;


            // Option 2 - Read by known SugarCRM module name - "Contacts".
            var contactRequest = new SugarRestRequest("Contacts", RequestType.ReadById);
            contactRequest.Id = contactid;
            SugarRestResponse contactRresponse = client.Execute(contactRequest);
            Contact contact = (Contact)contactRresponse.Data;


            // Option 3 - Read async by known type typeof(Case).
            var caseRequest = new SugarRestRequest(RequestType.ReadById);
            caseRequest.Id = caseId;
            SugarRestResponse caseResponse = await client.ExecuteAsync<Case>(caseRequest);
            Case case = (Case)caseResponse.Data;


            // Option 4 - Read async by known SugarCRM module name - "Leads".
            var leadRequest = new SugarRestRequest("Leads", RequestType.ReadById);
            leadRequest.Id = leadId;
            SugarRestResponse leadResponse = await client.ExecuteAsync(leadRequest);
            Lead lead = (Lead)leadResponse.Data;
```



<br>
</br>

### Advanced Sample Usage - Linked Module
This sample usage shows how to read "Accounts" module entity data with linked modules (link "Contacts" module). For more request options make changes to the [Options parameter](Request Options).

This implements the **_get_entry_** SugarCRM REST API method setting the **_link_name_to_fields_array_** parameter.

```cs
using SugarRestSharp;
using CustomModels;
using Newtonsoft.Json;

string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
string username = "will";
string password = "will";

var client = new SugarRestClient(url, username, password);
string accountId = "54bf59bc-ec61-1860-a97e-5777b5e92066";

var request = new SugarRestRequest(RequestType.LinkedReadById);
request.Parameter = accountId;

List<string> selectedFields = new List<string>();
selectedFields.Add(nameof(Account.Id));
selectedFields.Add(nameof(Account.Name));
selectedFields.Add(nameof(Account.Industry));
selectedFields.Add(nameof(Account.Website));
selectedFields.Add(nameof(Account.ShippingAddressCity));

request.Options.SelectFields = selectedFields;

Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();

List<string> selectContactFields = new List<string>();
selectContactFields.Add(nameof(Contact.FirstName));
selectContactFields.Add(nameof(Contact.LastName));
selectContactFields.Add(nameof(Contact.Title));
selectContactFields.Add(nameof(Contact.Description));
selectContactFields.Add(nameof(Contact.PrimaryAddressPostalcode));

linkedListInfo[typeof(Contact)] = selectContactFields;

request.Options.LinkedModules = linkedListInfo;

SugarRestResponse response = client.Execute<Account>(request)

```

### Custom model
```cs 
using Newtonsoft.Json;
using SugarRestSharp.Models;
using System.Collections.Generic;

public class CustomAcccount : Account
{
    [JsonProperty(PropertyName = "contacts")]
    public virtual List<Contact> ContactLink { get; set; }
}
```

### Response (Data)
```cs 
Data = null;

// Deserialize json data to custom object
CustomAcccount customAccount = JsonConvert.DeserializeObject<CustomAcccount>(response.JData);
```

### Response (JData)
```cs 
{
  "id": "54bf59bc-ec61-1860-a97e-5777b5e92066",
  "name": "Southern Realty",
  "industry": "Telecommunications",
  "website": "www.veganqa.tv",
  "shipping_address_city": "Santa Monica",
  "contacts": [
    {
      "first_name": "Cameron",
      "last_name": "Vanwingerden",
      "title": "IT Developer",
      "description": "",
      "primary_address_postalcode": "89219"
    },
    {
      "first_name": "Jessica",
      "last_name": "Mumma",
      "title": "VP Sales",
      "description": "",
      "primary_address_postalcode": "26988"
    },
    {
      "first_name": "Brianna",
      "last_name": "Gleeson",
      "title": "VP Operations",
      "description": "",
      "primary_address_postalcode": "70525"
    },
    {
      "first_name": "Miles",
      "last_name": "Gore",
      "title": "Director Sales",
      "description": "",
      "primary_address_postalcode": "82591"
    },
    {
      "first_name": "Georgia",
      "last_name": "Brendel",
      "title": "Director Sales",
      "description": "",
      "primary_address_postalcode": "63582"
    }
  ]
}
```

### Response (JsonRawRequest)
```cs 
{
  "resource": "",
  "parameters": [
    {
      "name": "method",
      "value": "get_entry",
      "type": "GetOrPost"
    },
    {
      "name": "input_type",
      "value": "json",
      "type": "GetOrPost"
    },
    {
      "name": "response_type",
      "value": "json",
      "type": "GetOrPost"
    },
    {
      "name": "rest_data",
      "value": "{\"session\":\"jc520u2ql973ec9m67n7935tu3\",\"module_name\":\"Accounts\",\"id\":\"54bf59bc-ec61-1860-a97e-5777b5e92066\",\"select_fields\":[\"id\",\"name\",\"industry\",\"website\",\"shipping_address_city\"],\"link_name_to_fields_array\":[{\"name\":\"contacts\",\"value\":[\"first_name\",\"last_name\",\"title\",\"description\",\"primary_address_postalcode\"]}],\"track_view\":false}",
      "type": "GetOrPost"
    },
    {
      "name": "Accept",
      "value": "application\/json, application\/xml, text\/json, text\/x-json, text\/javascript, text\/xml",
      "type": "HttpHeader"
    }
  ],
  "method": "POST",
  "uri": "http:\/\/191.101.224.189\/sugar\/service\/v4_1\/rest.php"
}
```

### Response (JsonRawResponse)
```cs 
{
  "statusCode": 200,
  "content": "{\"entry_list\":[{\"id\":\"54bf59bc-ec61-1860-a97e-5777b5e92066\",\"module_name\":\"Accounts\",\"name_value_list\":{\"id\":{\"name\":\"id\",\"value\":\"54bf59bc-ec61-1860-a97e-5777b5e92066\"},\"name\":{\"name\":\"name\",\"value\":\"Southern Realty\"},\"industry\":{\"name\":\"industry\",\"value\":\"Telecommunications\"},\"website\":{\"name\":\"website\",\"value\":\"www.veganqa.tv\"},\"shipping_address_city\":{\"name\":\"shipping_address_city\",\"value\":\"Santa Monica\"}}}],\"relationship_list\":[[{\"name\":\"contacts\",\"records\":[{\"first_name\":{\"name\":\"first_name\",\"value\":\"Cameron\"},\"last_name\":{\"name\":\"last_name\",\"value\":\"Vanwingerden\"},\"title\":{\"name\":\"title\",\"value\":\"IT Developer\"},\"description\":{\"name\":\"description\",\"value\":\"\"},\"primary_address_postalcode\":{\"name\":\"primary_address_postalcode\",\"value\":\"89219\"}},{\"first_name\":{\"name\":\"first_name\",\"value\":\"Jessica\"},\"last_name\":{\"name\":\"last_name\",\"value\":\"Mumma\"},\"title\":{\"name\":\"title\",\"value\":\"VP Sales\"},\"description\":{\"name\":\"description\",\"value\":\"\"},\"primary_address_postalcode\":{\"name\":\"primary_address_postalcode\",\"value\":\"26988\"}},{\"first_name\":{\"name\":\"first_name\",\"value\":\"Brianna\"},\"last_name\":{\"name\":\"last_name\",\"value\":\"Gleeson\"},\"title\":{\"name\":\"title\",\"value\":\"VP Operations\"},\"description\":{\"name\":\"description\",\"value\":\"\"},\"primary_address_postalcode\":{\"name\":\"primary_address_postalcode\",\"value\":\"70525\"}},{\"first_name\":{\"name\":\"first_name\",\"value\":\"Miles\"},\"last_name\":{\"name\":\"last_name\",\"value\":\"Gore\"},\"title\":{\"name\":\"title\",\"value\":\"Director Sales\"},\"description\":{\"name\":\"description\",\"value\":\"\"},\"primary_address_postalcode\":{\"name\":\"primary_address_postalcode\",\"value\":\"82591\"}},{\"first_name\":{\"name\":\"first_name\",\"value\":\"Georgia\"},\"last_name\":{\"name\":\"last_name\",\"value\":\"Brendel\"},\"title\":{\"name\":\"title\",\"value\":\"Director Sales\"},\"description\":{\"name\":\"description\",\"value\":\"\"},\"primary_address_postalcode\":{\"name\":\"primary_address_postalcode\",\"value\":\"63582\"}}]}]]}",
  "headers": [
    {
      "Name": "Pragma",
      "Value": "no-cache",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Content-Length",
      "Value": "1896",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Cache-Control",
      "Value": "no-store, no-cache, must-revalidate, post-check=0, pre-check=0",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Content-Type",
      "Value": "application\/json; charset=UTF-8",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Date",
      "Value": "Sun, 18 Dec 2016 03:47:57 GMT",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Expires",
      "Value": "Thu, 19 Nov 1981 08:52:00 GMT",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Set-Cookie",
      "Value": "PHPSESSID=jc520u2ql973ec9m67n7935tu3; path=\/",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "Server",
      "Value": "Apache\/2.4.7 (Ubuntu)",
      "Type": 3,
      "ContentType": null
    },
    {
      "Name": "X-Powered-By",
      "Value": "PHP\/5.5.9-1ubuntu4.17",
      "Type": 3,
      "ContentType": null
    }
  ],
  "responseUri": "http:\/\/191.101.224.189\/sugar\/service\/v4_1\/rest.php",
  "errorMessage": null
}
```

