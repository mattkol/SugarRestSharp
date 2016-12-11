// -----------------------------------------------------------------------
// <copyright file="AccountsModuleTests.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests
{
    using Helpers;
    using Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class AccountsModuleTests
    {
        [Fact]
        public void CRUDTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Account insertAccount = AccountsModule.GetTestAccount();

            // -------------------Create Account-------------------
            SugarRestResponse response = AccountsModule.CreateAccount(client, insertAccount);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = response.Id;

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Account-------------------


            // -------------------Read Account-------------------
            response = AccountsModule.ReadAccount(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Account readOnCreateAccount = (Account)response.Data;

            Assert.NotNull(readOnCreateAccount);
            Assert.Equal(insertAccount.Name, readOnCreateAccount.Name);
            Assert.Equal(insertAccount.Industry, readOnCreateAccount.Industry);
            Assert.Equal(insertAccount.Website, readOnCreateAccount.Website);
            Assert.Equal(insertAccount.ShippingAddressCity, readOnCreateAccount.ShippingAddressCity);
            // -------------------End Read Account-------------------


            // -------------------Update Account-------------------
            response = AccountsModule.UpdateAccount(client, readOnCreateAccount.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string updateId = response.Id;

            Assert.NotNull(updateId);
            Assert.NotEmpty(updateId);
            // -------------------End Update Account-------------------


            // -------------------Read Account-------------------
            response = AccountsModule.ReadAccount(client, updateId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Account readOnUpdateAccount = (Account)response.Data;

            Assert.NotNull(readOnUpdateAccount.Name);
            Assert.NotEmpty(readOnUpdateAccount.Name);
            Assert.Equal(updateId, updateId);
            Assert.NotEqual(readOnCreateAccount.Name, readOnUpdateAccount.Name);
            // -------------------End Read Account-------------------


            // -------------------Delete Account-------------------
            response = AccountsModule.DeleteAccount(client, updateId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = response.Id;

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Account-------------------
        }

        [Fact]
        public void BulkCRUDTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);
            List<Account> insertAccounts = AccountsModule.GetTestBulkAccount();

            // -------------------Create Bulk Account-------------------
            SugarRestResponse response = AccountsModule.BulkCreateAccount(client, insertAccounts);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<string> insertIds = response.Ids;

            Assert.NotNull(insertIds);
            Assert.Equal(insertAccounts.Count, insertIds.Count);

            foreach (string id in insertIds)
            {
                Assert.NotNull(id);
                Assert.NotEmpty(id);
            }
            // -------------------End Bulk Create Account-------------------


            // -------------------Bulk Read Account-------------------
            List<Account> readOnCreateAccounts = AccountsModule.BulkReadAccount2(client, insertIds);

            Assert.NotNull(readOnCreateAccounts);
            Assert.Equal(insertIds.Count, readOnCreateAccounts.Count);

            foreach (var account in readOnCreateAccounts)
            {
                Assert.NotNull(account);
                Assert.NotNull(account.Id);
                Assert.NotEmpty(account.Id);
            }

            // -------------------End Bulk Read Account-------------------


            // -------------------Bulk Update Account-------------------
            Dictionary<string, string> accountNameDic = new Dictionary<string, string>();

            foreach (var account in readOnCreateAccounts)
            {
                accountNameDic[account.Id] = account.Name;
            }

            response = AccountsModule.BulkUpdateAccount(client, readOnCreateAccounts);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<string> updateIds = response.Ids;

            Assert.NotNull(updateIds);
            foreach (string id in updateIds)
            {
                Assert.NotNull(id);
                Assert.NotEmpty(id);
            }
            // -------------------End Bulk Update Account-------------------


            // -------------------Bulk Read Account-------------------
            List<Account> readOnUpdateAccounts = AccountsModule.BulkReadAccount2(client, updateIds);

            Assert.NotNull(readOnUpdateAccounts);
            Assert.Equal(updateIds.Count, readOnUpdateAccounts.Count);

            foreach (var item in accountNameDic)
            {
                Account account = readOnUpdateAccounts.FirstOrDefault(x => x.Id == item.Key);
                Assert.NotNull(account);
                Assert.NotEqual(item.Value, account.Name);
            }
            // -------------------End Bulk Read Account-------------------


            // -------------------Bulk Delete Account-------------------
            List<string> deleteIds = AccountsModule.BulkDeleteAccount(client, updateIds);

            Assert.NotNull(deleteIds);
            Assert.Equal(updateIds.Count, deleteIds.Count);

            List<string> comparedIds = deleteIds.Except(updateIds, StringComparer.OrdinalIgnoreCase).ToList();

            if (comparedIds != null)
            {
                Assert.Equal(comparedIds.Count, 0);
            }
            // -------------------End Bulk Delete Account-------------------
        }

        [Fact]
        public void ReadByTypeTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Account insertAccount = AccountsModule.GetTestAccount();

            // -------------------Create Account-------------------
            SugarRestResponse response = AccountsModule.CreateAccountByType(client, insertAccount);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = response.Id;

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Account-------------------


            // -------------------Read Account-------------------
            response = AccountsModule.ReadAccountByType(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Account readOnCreateAccount = (Account) response.Data;

            Assert.NotNull(readOnCreateAccount);
            Assert.Equal(insertAccount.Name, readOnCreateAccount.Name);
            Assert.Equal(insertAccount.Industry, readOnCreateAccount.Industry);
            Assert.Equal(insertAccount.Website, readOnCreateAccount.Website);
            Assert.Equal(insertAccount.ShippingAddressCity, readOnCreateAccount.ShippingAddressCity);
            // -------------------End Read Account-------------------


            // -------------------Delete Account-------------------
            response = AccountsModule.DeleteAccountByType(client, readOnCreateAccount.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = response.Id;

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Account-------------------
        }

        [Fact]
        public void ReadByTypeJDataTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Account insertAccount = AccountsModule.GetTestAccount();

            // -------------------Create Account-------------------
            SugarRestResponse response = AccountsModule.CreateAccountByType(client, insertAccount);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = response.Id;

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Account-------------------


            // -------------------Read Account-------------------
            response = AccountsModule.ReadAccountByType(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            Assert.NotNull(response.JData);
            Assert.NotEmpty(response.JData);

            JObject jobject = JObject.Parse(response.JData);
            Assert.NotNull(jobject);

            var jproperties = jobject.Properties().ToList();
            List<string> selectedFields = AccountsModule.GetJsonSelectedField();

            Assert.Equal(selectedFields.Count, jproperties.Count);

            foreach (string id in selectedFields)
            {
                JProperty property = jproperties.SingleOrDefault(p => p.Name == id);
                Assert.NotNull(property);
            }

            Account readOnCreateAccount = (Account)response.Data;
            // -------------------End Read Account-------------------


            // -------------------Delete Account-------------------
            response = AccountsModule.DeleteAccountByType(client, readOnCreateAccount.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = response.Id;

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Account-------------------
        }

        [Fact]
        public async void ReadAsyncTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Account insertAccount = AccountsModule.GetTestAccount();

            // -------------------Create Account-------------------
            SugarRestResponse response = await AccountsModule.CreateAccountAsync(client, insertAccount);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = response.Id;

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Account-------------------


            // -------------------Read Account-------------------
            response = await AccountsModule.ReadAccountAsync(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Account readOnCreateAccount = (Account) response.Data;

            Assert.NotNull(readOnCreateAccount);
            Assert.Equal(insertAccount.Name, readOnCreateAccount.Name);
            Assert.Equal(insertAccount.Industry, readOnCreateAccount.Industry);
            Assert.Equal(insertAccount.Website, readOnCreateAccount.Website);
            Assert.Equal(insertAccount.ShippingAddressCity, readOnCreateAccount.ShippingAddressCity);
            // -------------------End Read Account-------------------


            // -------------------Delete Account-------------------
            response = await AccountsModule.DeleteAccountAsync(client, readOnCreateAccount.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = response.Id;

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Account-------------------
        }

        [Fact]
        public void ReadBulkTest()
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
        }

        [Fact]
        public async void ReadBulkAsyncTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Account-------------------
            int count = 25;
            SugarRestResponse response = await AccountsModule.BulkReadAccountAsync(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Account> readAccounts = (List<Account>) response.Data;
            Assert.NotNull(readAccounts);
            Assert.True(readAccounts.Count <= count);
            // -------------------End Bulk Read Account-------------------
        }
    }
}
