// -----------------------------------------------------------------------
// <copyright file="AccountsModule.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests.Helpers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal static class AccountsModule
    {
        public static SugarRestResponse CreateAccount(SugarRestClient client, Account account)
        {
            var request = new SugarRestRequest("Accounts", RequestType.Create);
            request.Data = account;

            request.Options.SelectFields = GetSelectedField();

            return client.Execute(request);
        }

        public static SugarRestResponse CreateAccountByType(SugarRestClient client, Account account)
        {
            var request = new SugarRestRequest(RequestType.Create);
            request.Data = account;

            request.Options.SelectFields = GetSelectedField();

            return client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> CreateAccountAsync(SugarRestClient client, Account account)
        {
            var request = new SugarRestRequest(RequestType.Create);
            request.Data = account;

            request.Options.SelectFields = GetSelectedField();

            return await client.ExecuteAsync<Account>(request);
        }


        public static SugarRestResponse BulkCreateAccount(SugarRestClient client, List<Account> accounts)
        {
            var request = new SugarRestRequest("Accounts", RequestType.BulkCreate);
            request.Data = accounts;
            request.Options.SelectFields = GetSelectedField();
            return client.Execute(request);
        }

        public static SugarRestResponse ReadAccount(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest("Accounts", RequestType.ReadById);
            request.Id = accountId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Account.Id));

            return client.Execute(request);
        }

        public static SugarRestResponse ReadAccountByType(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest(RequestType.ReadById);
            request.Id = accountId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Account.Id));

            return client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> ReadAccountAsync(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest(RequestType.ReadById);
            request.Id = accountId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Account.Id));

            return await client.ExecuteAsync<Account>(request);
        }

        public static SugarRestResponse BulkReadAccount(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest("Accounts", RequestType.BulkRead);

            request.Options.SelectFields = GetSelectedField(); 
            request.Options.SelectFields.Add(nameof(Account.Id));

            request.Options.MaxResult = count;

            return client.Execute(request);
        }

        public static async Task<SugarRestResponse> BulkReadAccountAsync(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest();
            request.RequestType = RequestType.BulkRead;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Account.Id));

            request.Options.MaxResult = count;

            return await client.ExecuteAsync<Account>(request);
        }

        public static List<Account> BulkReadAccount2(SugarRestClient client, List<string> accountIds)
        {
            var request = new SugarRestRequest("Accounts", RequestType.ReadById);

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Account.Id));

            List<Account> accounts = new List<Account>();

            foreach (var id in accountIds)
            {
                request.Id = id;
                SugarRestResponse response = client.Execute(request);

                accounts.Add((Account)response.Data);
            }

            return accounts;
        }

        public static SugarRestResponse UpdateAccount(SugarRestClient client, string identifier)
        {
            Random random = new Random();
            int uniqueNumber = 10000 + random.Next(100, 999);

            Account account = new Account();
            account.Id = identifier;
            account.Name = "Update SugarRestSharp Acccount " + uniqueNumber;

            var request = new SugarRestRequest("Accounts", RequestType.Update);
            request.Data = account;

            request.Options.SelectFields = new List<string>();
            request.Options.SelectFields.Add(nameof(Account.Name));

            return client.Execute(request);
        }

        public static SugarRestResponse BulkUpdateAccount(SugarRestClient client, List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                account.Name = account.Name.Replace("New", "Update");
            }

            var request = new SugarRestRequest("Accounts", RequestType.BulkUpdate);
            request.Data = accounts;

            request.Options.SelectFields = new List<string>();
            request.Options.SelectFields.Add(nameof(Account.Name));

            return client.Execute(request);
        }

        public static SugarRestResponse DeleteAccount(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest("Accounts", RequestType.Delete);
            request.Id = accountId;

            return client.Execute(request);
        }

        public static SugarRestResponse DeleteAccountByType(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest(RequestType.Delete);
            request.Id = accountId;

            return client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> DeleteAccountAsync(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest("Accounts", RequestType.Delete);
            request.Id = accountId;

            return await client.ExecuteAsync(request);
        }

        public static List<string> BulkDeleteAccount(SugarRestClient client, List<string> accountIds)
        {
            var request = new SugarRestRequest("Accounts", RequestType.Delete);

            List<string> listId = new List<string>();
            foreach (var id in accountIds)
            {
                request.Id = id;
                SugarRestResponse response = client.Execute(request);
                listId.Add(response.Id);
            }

            return listId;
        }

        public static List<string> GetSelectedField()
        {
            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Account.Name));
            selectedFields.Add(nameof(Account.Industry));
            selectedFields.Add(nameof(Account.Website));
            selectedFields.Add(nameof(Account.ShippingAddressCity));

            return selectedFields;
        }

        public static List<string> GetJsonSelectedField()
        {
            List<string> selectedFields = new List<string>();

            selectedFields.Add("id");
            selectedFields.Add("name");
            selectedFields.Add("industry");
            selectedFields.Add("website");
            selectedFields.Add("shipping_address_city");

            return selectedFields;
        }

        public static Account GetTestAccount()
        {
            Random random = new Random();
            int uniqueNumber = 10000 + random.Next(100, 999);

            Account account = new Account();
            account.Name = "New SugarRestSharp Acccount " + uniqueNumber;
            account.Industry = "Manufacturing";
            account.Website = "www.sugarrestsharp.com";
            account.ShippingAddressCity = "Los Angeles";

            return account;
        }

        public static List<Account> GetTestBulkAccount()
        {
            Random random = new Random();
            int uniqueNumber = 10000 + random.Next(100, 999);

            List<Account> accounts = new List<Account>();

            Account account = new Account();
            account.Name = "New SugarRestSharp Acccount 1 " + uniqueNumber;
            account.Industry = "Manufacturing";
            account.Website = "www.sugarrestsharp1.com";
            account.ShippingAddressCity = "Los Angeles";

            accounts.Add(account);

            account = new Account();
            account.Name = "New SugarRestSharp Acccount 2 " + uniqueNumber;
            account.Industry = "Fishing";
            account.Website = "www.sugarrestsharp2.com";
            account.ShippingAddressCity = "New York";

            accounts.Add(account);


            account = new Account();
            account.Name = "New SugarRestSharp Acccount 3 " + uniqueNumber;
            account.Industry = "Finance";
            account.Website = "www.sugarrestsharp3.com";
            account.ShippingAddressCity = "New Orlean";

            accounts.Add(account);

            account = new Account();
            account.Name = "New SugarRestSharp Acccount 4 " + uniqueNumber;
            account.Industry = "Computing";
            account.Website = "www.sugarrestsharp4.com";
            account.ShippingAddressCity = "New Orlean";

            accounts.Add(account);

            account = new Account();
            account.Name = "New SugarRestSharp Acccount 5 " + uniqueNumber;
            account.Industry = "Shipping";
            account.Website = "www.sugarrestsharp5.com";
            account.ShippingAddressCity = "New Orlean";

            accounts.Add(account);

            return accounts;
        }
    }
}
