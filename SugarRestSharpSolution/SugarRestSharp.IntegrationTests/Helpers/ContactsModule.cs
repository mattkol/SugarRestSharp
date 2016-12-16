// -----------------------------------------------------------------------
// <copyright file="ContactsModule.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests.Helpers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal static class ContactsModule
    {
        public static SugarRestResponse CreateContact(SugarRestClient client, Contact contact)
        {
            var request = new SugarRestRequest("Contacts", RequestType.Create);
            request.Parameter = contact;

            request.Options.SelectFields = GetSelectedField();

            return client.Execute(request);
        }

        public static SugarRestResponse CreateContactByType(SugarRestClient client, Contact contact)
        {
            var request = new SugarRestRequest(RequestType.Create);
            request.Parameter = contact;

            request.Options.SelectFields = GetSelectedField();

            return client.Execute<Contact>(request);
        }

        public static async Task<SugarRestResponse> CreateContactAsync(SugarRestClient client, Contact contact)
        {
            var request = new SugarRestRequest(RequestType.Create);
            request.Parameter = contact;

            request.Options.SelectFields = GetSelectedField();

            return await client.ExecuteAsync<Contact>(request);
        }


        public static SugarRestResponse BulkCreateContact(SugarRestClient client, List<Contact> contacts)
        {
            var request = new SugarRestRequest("Contacts", RequestType.BulkCreate);
            request.Parameter = contacts;

            request.Options.SelectFields = GetSelectedField();

            return client.Execute(request);
        }

        public static SugarRestResponse ReadContact(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest("Contacts", RequestType.ReadById);
            request.Parameter = contactId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            return client.Execute(request);
        }

        public static SugarRestResponse ReadContactByType(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest(RequestType.ReadById);
            request.Parameter = contactId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            return client.Execute<Contact>(request);
        }

        public static async Task<SugarRestResponse> ReadContactAsync(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest(RequestType.ReadById);
            request.Parameter = contactId;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            return await client.ExecuteAsync<Contact>(request);
        }

        public static SugarRestResponse BulkReadContact(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest("Contacts", RequestType.BulkRead);

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            request.Options.MaxResult = count;

            return client.Execute(request);
        }

        public static async Task<SugarRestResponse> BulkReadContactAsync(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest();
            request.RequestType = RequestType.BulkRead;

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            request.Options.MaxResult = count;

            return await client.ExecuteAsync<Contact>(request);
        }

        public static List<Contact> BulkReadContact2(SugarRestClient client, List<string> contactIds)
        {
            var request = new SugarRestRequest("Contacts", RequestType.ReadById);

            request.Options.SelectFields = GetSelectedField();
            request.Options.SelectFields.Add(nameof(Contact.Id));

            List<Contact> contacts = new List<Contact>();

            foreach (var id in contactIds)
            {
                request.Parameter = id;
                SugarRestResponse response = client.Execute(request);

                contacts.Add((Contact) response.Data);
            }

            return contacts;
        }

        public static SugarRestResponse UpdateContact(SugarRestClient client, string identifier)
        {
            Random random = new Random();
            int uniqueNumber = 10000 + random.Next(100, 999);

            Contact contact = new Contact();
            contact.Id = identifier;
            contact.Title = "Vice President of Programming";

            var request = new SugarRestRequest("Contacts", RequestType.Update);
            request.Parameter = contact;

            request.Options.SelectFields = new List<string>();
            request.Options.SelectFields.Add(nameof(Contact.Title));

            return client.Execute(request);
        }

        public static SugarRestResponse BulkUpdateContact(SugarRestClient client, List<Contact> contacts)
        {
            Random random = new Random();
            foreach (var contact in contacts)
            {
                contact.PrimaryAddressPostalcode = (10000 + random.Next(100, 999)).ToString();
            }

            var request = new SugarRestRequest("Contacts", RequestType.BulkUpdate);
            request.Parameter = contacts;

            request.Options.SelectFields = new List<string>();
            request.Options.SelectFields.Add(nameof(Contact.PrimaryAddressPostalcode));

            return client.Execute(request);
        }

        public static SugarRestResponse DeleteContact(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest("Contacts", RequestType.Delete);
            request.Parameter = contactId;

            return client.Execute(request);
        }

        public static SugarRestResponse DeleteContactByType(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest(RequestType.Delete);
            request.Parameter = contactId;

            return client.Execute<Contact>(request);
        }

        public static async Task<SugarRestResponse> DeleteContactAsync(SugarRestClient client, string contactId)
        {
            var request = new SugarRestRequest("Contacts", RequestType.Delete);
            request.Parameter = contactId;

            return await client.ExecuteAsync(request);
        }

        public static List<string> BulkDeleteContact(SugarRestClient client, List<string> contactIds)
        {
            var request = new SugarRestRequest("Contacts", RequestType.Delete);

            List<string> listId = new List<string>();
            foreach (var id in contactIds)
            {
                request.Parameter = id;
                SugarRestResponse response = client.Execute(request);
                string identifier = (response.Data == null) ? string.Empty : response.Data.ToString();
                listId.Add(identifier);
            }

            return listId;
        }

        public static List<string> GetSelectedField()
        {
            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Contact.FirstName));
            selectedFields.Add(nameof(Contact.LastName));
            selectedFields.Add(nameof(Contact.Title));
            selectedFields.Add(nameof(Contact.Description));
            selectedFields.Add(nameof(Contact.PrimaryAddressPostalcode));

            return selectedFields;
        }

        public static List<string> GetJsonSelectedField()
        {
            List<string> selectedFields = new List<string>();

            selectedFields.Add("id");
            selectedFields.Add("first_name");
            selectedFields.Add("last_name");
            selectedFields.Add("title");
            selectedFields.Add("description");
            selectedFields.Add("primary_address_postalcode");

            return selectedFields;
        }

        public static Contact GetTestContact()
        {
            Contact contact = new Contact();
            contact.FirstName = "Carolyn";
            contact.LastName = "Smith";
            contact.Title = "Director of Programming";
            contact.Description = "Likely lead for next project";
            contact.PrimaryAddressPostalcode = "65554";

            return contact;
        }

        public static List<Contact> GetTestBulkContact()
        {
            Random random = new Random();

            List<Contact> contacts = new List<Contact>();

            for (int i = 0; i < 5; i++)
            {
                Contact contact = new Contact();
                int uniqueNumber = 10000 + random.Next(100, 999);
                contact.FirstName = "FirstName_" + uniqueNumber;
                contact.LastName = "LastName_" + uniqueNumber;
                contact.Title = "Title_" + uniqueNumber;
                contact.PrimaryAddressPostalcode = uniqueNumber.ToString();

                contacts.Add(contact);
            }

            return contacts;
        }
    }
}
