// -----------------------------------------------------------------------
// <copyright file="QueryTests.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class QueryTests
    {
        [Fact]
        public void ReadBulkWithQuery1Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;

            var request = new SugarRestRequest("Accounts", RequestType.BulkRead);

            request.Options.Query = "accounts.name = 'Air Safety Inc' ";
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Account.Name), QueryOperator.Equal, "General Electric USA, Inc"));
            request.Options.MaxResult = count;

            SugarRestResponse response = client.Execute(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) (response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.All(x => x.Name == "Air Safety Inc"));
            // -------------------End Bulk Read Account-------------------
        }

        [Fact]
        public void ReadBulkWithPredicateTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;

            var request = new SugarRestRequest("Accounts", RequestType.BulkRead);

            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Account.Name), QueryOperator.Equal, "Air Safety Inc"));
            request.Options.MaxResult = count;

            SugarRestResponse response = client.Execute(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) (response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.All(x => x.Name == "Air Safety Inc"));
            // -------------------End Bulk Read Account-------------------
        }

        [Fact]
        public void ReadBulkWithQuery2Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;
            var request = new SugarRestRequest(RequestType.BulkRead);
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.MaxResult = count;

            SugarRestResponse response = client.Execute<Lead>(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Lead> readLeads = (List<Lead>) (response.Data);
            List<string> identifiers = readLeads.Select(x => x.Id).ToList();
            // -------------------End Bulk Read Account-------------------

            // -------------------Bulk Read Account-------------------
            request = new SugarRestRequest(RequestType.BulkRead);
            request.Options.Query = "leads.id IN('10d82d59-08eb-8f0d-28e0-5777b57af47c', '12037cd0-ead2-402e-e1d0-5777b5dfb965', '13d4109d-c5ca-7dd1-99f1-5777b57ef30f', '14c136e5-1a67-eeba-581c-5777b5c8c463', '14e4825e-9573-4d75-2dbe-5777b5b7ee85', '1705b33a-3fad-aa70-77ef-5777b5b081f1', '171c1d8b-e34f-3a1f-bef7-5777b5ecc823', '174a8fc4-56e6-3471-46d8-5777b565bf5b', '17c9c496-90a1-02f5-87bd-5777b51ab086', '1d210352-7a1f-2c5d-04ae-5777b5a3312f')";
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Lead.LastName), QueryOperator.Equal, "Johnson"));
            request.Options.MaxResult = count;

            response = client.Execute<Lead>(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Lead> readLeadsWithQuery = (List<Lead>) (response.Data);
            Assert.NotNull(readLeadsWithQuery);

            List<string> newIdentifiers = readLeads.Select(x => x.Id).ToList();
            List<string> commonIdentifiers = identifiers.Intersect(newIdentifiers).ToList();

            Assert.Equal(readLeads.Count, readLeadsWithQuery.Count);
            Assert.Equal(identifiers.Count, newIdentifiers.Count);
            Assert.Equal(identifiers.Count, commonIdentifiers.Count);
            // -------------------End Bulk Read Account-------------------
        }

        [Fact]
        public void ReadBulkWithPredicate2Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;
            var request = new SugarRestRequest(RequestType.BulkRead);
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.MaxResult = count;

            SugarRestResponse response = client.Execute<Lead>(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Lead> readLeads = (List<Lead>) (response.Data);
            List<string> identifiers = readLeads.Select(x => x.Id).ToList();
            // -------------------End Bulk Read Account-------------------

            // -------------------Bulk Read Account-------------------
            request = new SugarRestRequest(RequestType.BulkRead);
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Lead.Id), QueryOperator.WhereIn, identifiers));
            request.Options.MaxResult = count;

            response = client.Execute<Lead>(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Lead> readLeadsWithQuery = (List<Lead>) (response.Data);
            Assert.NotNull(readLeadsWithQuery);

            List<string> newIdentifiers = readLeads.Select(x => x.Id).ToList();
            List<string> commonIdentifiers = identifiers.Intersect(newIdentifiers).ToList();

            Assert.Equal(readLeads.Count, readLeadsWithQuery.Count);
            Assert.Equal(identifiers.Count, newIdentifiers.Count);
            Assert.Equal(identifiers.Count, commonIdentifiers.Count);
            // -------------------End Bulk Read Account-------------------
        }

        [Fact]
        public async void ReadBulkAsyncWithQueryTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 25;

            var request = new SugarRestRequest("Cases", RequestType.BulkRead);
            request.Options.QueryPredicates = new List<QueryPredicate>();
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Name), QueryOperator.StartsWith, "Warning"));
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Name), QueryOperator.Contains, "message"));
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.Status), QueryOperator.Equal, "Assigned"));
            DateTime date = DateTime.Parse("07/02/2016");
            request.Options.QueryPredicates.Add(new QueryPredicate(nameof(Case.DateEntered), QueryOperator.Between, null, date.AddDays(-1), DateTime.Now));
            request.Options.MaxResult = count;

            SugarRestResponse response = await client.ExecuteAsync<Case>(request);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Case> readACases = (List<Case>) response.Data;
            Assert.NotNull(readACases);
            Assert.True(readACases.Count <= count);
            Assert.True(readACases.All(x => x.Name.StartsWith("Warning")));
            Assert.True(readACases.All(x => x.Name.Contains("message")));
            Assert.True(readACases.All(x => x.Status == "Assigned"));

            // -------------------End Bulk Read Account-------------------
        }
    }
}
