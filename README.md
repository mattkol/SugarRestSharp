# .NET C# SugarCRM REST API (v4_1) Client
SugarRestSharp is a .NET C# SugarCRM CE 6.5 API client. It is a Restful CRUD client that implements the SugarCRM module Create, Read, Update and Delete functionalities.

SugarRestSharp implements following SugarCRM REST API method calls: **_oauth_access, get_entry, get_entry_list, set_entry, set_entries._**

### Sample Usages
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



