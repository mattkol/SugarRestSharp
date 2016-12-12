// -----------------------------------------------------------------------
// <copyright file="LinkedModulesTests.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests
{
    using CustomModels;
    using Helpers;
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using Xunit;

    public class LinkedModulesTests
    {
        [Fact]
        public void LinkedRead1Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;
            SugarRestResponse response = AccountsModule.BulkReadAccount(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>)(response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.Count <= count);
            // -------------------End Bulk Read Account-------------------


            // -------------------Read Account Link Contact-------------------
            string accountId = readAccounts[count - 1].Id;
            response = LinkedModules.ReadAccountLinkContact(client, accountId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Assert.True(response.Data == null);
            Assert.NotEmpty(response.JData);
            Assert.NotEmpty(response.JData);

            // Deserialize json data to custom object
            CustomAcccount1 customAccount = JsonConvert.DeserializeObject<CustomAcccount1>(response.JData);

            Assert.NotNull(customAccount);
            Assert.Equal(accountId, customAccount.Id);

            // -------------------End Read Account Link Contact-------------------
        }

        [Fact]
        public void LinkedRead2Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 10;
            SugarRestResponse response = AccountsModule.BulkReadAccount(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) (response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.Count <= count);
            // -------------------End Bulk Read Account-------------------


            // -------------------Read Account Link Concat-------------------
            string accountId = readAccounts[count - 1].Id;
            response = LinkedModules.ReadAccountLinkItems(client, accountId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Assert.True(response.Data == null);
            Assert.NotEmpty(response.JData);
            Assert.NotEmpty(response.JData);

            // Deserialize json data to custom object
            CustomAcccount2 customAccount = JsonConvert.DeserializeObject<CustomAcccount2>(response.JData);

            Assert.NotNull(customAccount);
            Assert.Equal(accountId, customAccount.Id);

            // -------------------End Read Account Link Concat-------------------
        }

        [Fact]
        public void BulkLinkedRead1Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Read Account Link Contact-------------------
            int count = 10;
            SugarRestResponse response = LinkedModules.BulkReadAccountLinkContact(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) (response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.Count <= count);
            // -------------------End Account Link Contact-------------------
        }

        [Fact]
        public void BulkLinkedRead2Test()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Read Account Link Contact-------------------
            int count = 10;
            SugarRestResponse response = LinkedModules.BulkReadAccountLinkItems(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) (response.Data);
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.Count <= count);
            // -------------------End Account Link Contact-------------------
        }
    }
}