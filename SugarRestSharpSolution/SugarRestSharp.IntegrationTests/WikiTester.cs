// -----------------------------------------------------------------------
// <copyright file="WikiTester.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests
{
    using CustomModels;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class WikiTester
    {
        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiReadLeadTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            string moduleName = "Leads";
            string moduleId = "10d82d59-08eb-8f0d-28e0-5777b57af47c";

            var client = new SugarRestClient(url, username, password);
            var request = new SugarRestRequest(moduleName, RequestType.ReadById);
            request.Parameter = moduleId;

            SugarRestResponse response = client.Execute(request);

            Lead lead = (Lead) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public async void WikiReadContactsByPageAsyncTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);
            var request = new SugarRestRequest(RequestType.PagedRead);

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Contact.FirstName));

            // You can mix C# type and json type.
            selectFields.Add("last_name");

            request.Options.SelectFields = selectFields;

            // Sets page options
            request.Options.CurrentPage = 1;
            request.Options.NumberPerPage = 10;
            SugarRestResponse response = await client.ExecuteAsync<Contact>(request);

            List<Contact> cases = (List<Contact>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiReadCasesTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            string moduleName = "Cases";

            var client = new SugarRestClient(url, username, password);
            var request = new SugarRestRequest(moduleName, RequestType.BulkRead);

            // Parameter can be set to null or leave unset.
            request.Parameter = null;

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Case.Id));
            selectFields.Add(nameof(Case.Name));

            // You can mix C# type and json type.
            selectFields.Add("status");
            selectFields.Add("created_by");

            request.Options.SelectFields = selectFields;

            // Select only 5 entities.
            // 5 is maximum, if all cases less than 5, less than 5 will be returned.
            request.Options.MaxResult = 5;
            SugarRestResponse response = client.Execute(request);

            List<Case> cases = (List<Case>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiCreateBugTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            string moduleName = "Bugs";

            var client = new SugarRestClient(url, username, password);
            var request = new SugarRestRequest(moduleName, RequestType.Create);

            Bug bugToCreate = new Bug();
            bugToCreate.Name = "System crashed while running count query";
            bugToCreate.Description = "New Oracle application server commissioning.";
            bugToCreate.Status = "New";

            request.Parameter = bugToCreate;

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Bug.Name));
            selectFields.Add(nameof(Bug.Description));
            selectFields.Add(nameof(Bug.Status));

            request.Options.SelectFields = selectFields;

            SugarRestResponse response = client.Execute(request);

            string bugId = (string) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiCreateBugsTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);
            var request = new SugarRestRequest(RequestType.BulkCreate);

            Bug bugToCreate1 = new Bug();
            bugToCreate1.Name = "System crashed while running new photo upload.";
            bugToCreate1.Description = "Tumblr app";
            bugToCreate1.Status = "Pending";

            Bug bugToCreate2 = new Bug();
            bugToCreate2.Name = "Warning is displayed in file after exporting.";
            bugToCreate2.Description = "";
            bugToCreate2.Status = "New";

            Bug bugToCreate3 = new Bug();
            bugToCreate3.Name = "Fatal error during installation.";
            bugToCreate3.Description = "Fifth floor printer.";
            bugToCreate3.Status = "Closed";

            List<Bug> bugsToCreate = new List<Bug>();
            bugsToCreate.Add(bugToCreate1);
            bugsToCreate.Add(bugToCreate2);
            bugsToCreate.Add(bugToCreate3);

            request.Parameter = bugsToCreate;

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Bug.Name));
            selectFields.Add(nameof(Bug.Description));
            selectFields.Add(nameof(Bug.Status));

            request.Options.SelectFields = selectFields;

            SugarRestResponse response = client.Execute<Bug>(request);

            List<string> createdBugIds = (List<string>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiUpdateBugTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);
            var readRequest = new SugarRestRequest("Bugs", RequestType.ReadById);
            string bugId = "e0b5b164-1bb4-65e9-5166-5855bfb57264";
            readRequest.Parameter = bugId;
            SugarRestResponse bugReadResponse = client.Execute(readRequest);
            Bug bugToUpdate = (Bug) bugReadResponse.Data;

            var request = new SugarRestRequest(RequestType.Update);

            // Update description 
            bugToUpdate.Description = "Now 7th floor printer";
            request.Parameter = bugToUpdate;

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Bug.Name));
            selectFields.Add(nameof(Bug.Description));
            selectFields.Add(nameof(Bug.Status));

            request.Options.SelectFields = selectFields;

            SugarRestResponse response = client.Execute<Bug>(request);

            string updatedBugId = (string) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiUpdateLeadsTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);
            var readRequest = new SugarRestRequest("Leads", RequestType.BulkRead);
            readRequest.Options.MaxResult = 3;

            SugarRestResponse leadsReadResponse = client.Execute(readRequest);
            List<Lead> leadsToUpdate = (List<Lead>) leadsReadResponse.Data;

            var request = new SugarRestRequest(RequestType.BulkUpdate);

            // Update account description 
            foreach (var lead in leadsToUpdate)
            {
                lead.AccountDescription = string.Format("Lead Account moved on {0}.", DateTime.Now.ToShortDateString());
            }

            request.Parameter = leadsToUpdate;

            // Select fields.
            List<string> selectFields = new List<string>();
            selectFields.Add(nameof(Lead.AccountName));
            selectFields.Add(nameof(Lead.AccountDescription));
            selectFields.Add(nameof(Lead.Status));

            request.Options.SelectFields = selectFields;

            SugarRestResponse response = client.Execute<Lead>(request);

            List<string> updatedLeadIds = (List<string>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiDeleteBugTest()
        {
            // using SugarRestSharp;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);
            string bugId = "49a8ff9f-e1d4-2135-c132-5855b99916a6";

            var request = new SugarRestRequest(RequestType.Delete);
            request.Parameter = bugId;

            SugarRestResponse response = client.Execute<Bug>(request);

            string deletedBugId = (string) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiReadLinkedAccountTest()
        {
            // using SugarRestSharp;
            // using CustomModels;
            // using Newtonsoft.Json;

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

            SugarRestResponse response = client.Execute<Account>(request);

            // Deserialize json data to custom object
            CustomAcccount1 customAccount = JsonConvert.DeserializeObject<CustomAcccount1>(response.JData);
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiReadLinkedAccountCollectionTest()
        {
            // using SugarRestSharp;
            // using CustomModels;
            // using Newtonsoft.Json;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            var request = new SugarRestRequest(RequestType.LinkedBulkRead);
            request.Parameter = null;

            request.Options.MaxResult = 3;

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

            SugarRestResponse response = client.Execute<Account>(request);

            // Deserialize json data to custom object
            List<CustomAcccount2> customAccounts = JsonConvert.DeserializeObject<List<CustomAcccount2>>(response.JData);
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiReadLinkedAccountCollection2Test()
        {
            // using SugarRestSharp;
            // using CustomModels;
            // using Newtonsoft.Json;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            var request = new SugarRestRequest(RequestType.LinkedBulkRead);
            request.Parameter = null;

            request.Options.MaxResult = 3;

            List<string> selectedFields = new List<string>();

            selectedFields.Add("id");
            selectedFields.Add("name");
            selectedFields.Add("industry");
            selectedFields.Add("website");

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();

            List<string> selectCaseFields = new List<string>();
            selectCaseFields.Add(nameof(Case.AccountId));
            selectCaseFields.Add(nameof(Case.CaseNumber));
            selectCaseFields.Add("description");

            linkedListInfo[typeof(Case)] = selectCaseFields;

            // Get all fields for Bug
            linkedListInfo["Bugs"] = null;

            request.Options.LinkedModules = linkedListInfo;

            SugarRestResponse response = client.Execute<Account>(request);

            // Deserialize json data to custom object
            List<CustomAcccount3> customAccounts = JsonConvert.DeserializeObject<List<CustomAcccount3>>(response.JData);
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public async void WikiReadCasesWithQueryPredicatesTest()
        {
            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            var request = new SugarRestRequest(RequestType.BulkRead);
            request.Options.MaxResult = 3;

            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Name), QueryOperator.StartsWith, "Warning"));
            request.Options.QueryPredicates.Add(new QueryPredicate("name", QueryOperator.Contains, "message"));
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Status), QueryOperator.Equal, "Assigned"));
            DateTime date = DateTime.Parse("07/02/2016");
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.DateEntered), QueryOperator.Between, null, date.AddDays(-1), DateTime.Now));

            SugarRestResponse response = await client.ExecuteAsync<Case>(request);

            List<Case> cases = (List<Case>)response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public async void WikiReadLeadsWithQueryTest()
        {
            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            var request = new SugarRestRequest(RequestType.BulkRead);

            List<string> selectedFields = new List<string>();

            selectedFields.Add("id");
            selectedFields.Add("name");
            selectedFields.Add("modified_by_name");

            request.Options.SelectFields = selectedFields;

            // Set query
            request.Options.Query = "leads.id IN('10d82d59-08eb-8f0d-28e0-5777b57af47c', '12037cd0-ead2-402e-e1d0-5777b5dfb965', '13d4109d-c5ca-7dd1-99f1-5777b57ef30f', '14c136e5-1a67-eeba-581c-5777b5c8c463', '14e4825e-9573-4d75-2dbe-5777b5b7ee85', '1705b33a-3fad-aa70-77ef-5777b5b081f1', '171c1d8b-e34f-3a1f-bef7-5777b5ecc823', '174a8fc4-56e6-3471-46d8-5777b565bf5b', '17c9c496-90a1-02f5-87bd-5777b51ab086', '1d210352-7a1f-2c5d-04ae-5777b5a3312f')";

            SugarRestResponse response = await client.ExecuteAsync<Lead>(request);

            List<Lead> leads = (List<Lead>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public async void WikiReadAccountsWithQueryIgnorePredicatesTest()
        {
            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            var request = new SugarRestRequest(RequestType.BulkRead);

            request.Options.Query = "accounts.name = 'Air Safety Inc' ";
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Account.Name), QueryOperator.Equal, "General Electric USA, Inc"));

            SugarRestResponse response = await client.ExecuteAsync<Account>(request);

            List<Account> accounts = (List<Account>) response.Data;
            // -------------------End Bulk Read Account-------------------
        }

        /*  Remove comment to test.
        [Fact] 
        */
        public void WikiDeleteEntitiesTest()
        {
            // using SugarRestSharp;
            // using CustomModels;
            // using Newtonsoft.Json;

            string url = "http://191.101.224.189/sugar/service/v4_1/rest.php";
            string username = "will";
            string password = "will";

            var client = new SugarRestClient(url, username, password);

            string moduleName = "Accounts";
            var request = new SugarRestRequest(moduleName, RequestType.Delete);

            List<string> itemIdsToDelete = new List<string>();
            itemIdsToDelete.Add("45ac2050-d55e-70ab-6520-585337eac1bc");
            itemIdsToDelete.Add("698e4f22-a213-d287-94be-584c09710444");
            itemIdsToDelete.Add("fb7405da-fe66-f0f9-f5d4-58533747bdf8");

            foreach (var id in itemIdsToDelete)
            {
                request.Parameter = id;
                SugarRestResponse response = client.Execute<Account>(request);
                string deletedItemId = (string) response.Data;
            }
        }
    }
}
