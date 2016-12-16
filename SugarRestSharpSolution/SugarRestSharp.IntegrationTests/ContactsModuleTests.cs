// -----------------------------------------------------------------------
// <copyright file="ContactsModuleTests.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests
{
    using Helpers;
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class ContactsModuleTests
    {
        [Fact]
        public void CRUDTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Contact insertContact = ContactsModule.GetTestContact();

            // -------------------Create Contact-------------------
            SugarRestResponse response = ContactsModule.CreateContact(client, insertContact);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Contact-------------------


            // -------------------Read Contact-------------------
            response = ContactsModule.ReadContact(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Contact readOnCreateContact = (Contact) response.Data;

            Assert.NotNull(readOnCreateContact);
            Assert.Equal(insertContact.FirstName, readOnCreateContact.FirstName);
            Assert.Equal(insertContact.LastName, readOnCreateContact.LastName);
            Assert.Equal(insertContact.Title, readOnCreateContact.Title);
            Assert.Equal(insertContact.PrimaryAddressPostalcode, readOnCreateContact.PrimaryAddressPostalcode);
            // -------------------End Read Contact-------------------


            // -------------------Update Contact-------------------
            response = ContactsModule.UpdateContact(client, readOnCreateContact.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string updateId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(updateId);
            Assert.NotEmpty(updateId);
            // -------------------End Update Contact-------------------


            // -------------------Read Contact-------------------
            response = ContactsModule.ReadContact(client, updateId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Contact readOnUpdateContact = (Contact) response.Data;

            Assert.NotNull(readOnUpdateContact.Title);
            Assert.NotEmpty(readOnUpdateContact.Title);
            Assert.Equal(updateId, updateId);
            Assert.NotEqual(readOnCreateContact.Title, readOnUpdateContact.Title);
            // -------------------End Read Contact-------------------


            // -------------------Delete Contact-------------------
            response = ContactsModule.DeleteContact(client, updateId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Contact-------------------
        }

        [Fact]
        public void BulkCRUDTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);
            List<Contact> insertContacts = ContactsModule.GetTestBulkContact();

            // -------------------Create Bulk Contact-------------------
            SugarRestResponse response = ContactsModule.BulkCreateContact(client, insertContacts);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<string> insertIds = (response.Data == null) ? null : ((IList) response.Data).Cast<string>().ToList();

            Assert.NotNull(insertIds);
            Assert.Equal(insertContacts.Count, insertIds.Count);

            foreach (string id in insertIds)
            {
                Assert.NotNull(id);
                Assert.NotEmpty(id);
            }
            // -------------------End Bulk Create Contact-------------------


            // -------------------Bulk Read Contact-------------------
            List<Contact> readOnCreateContacts = ContactsModule.BulkReadContact2(client, insertIds);

            Assert.NotNull(readOnCreateContacts);
            Assert.Equal(insertIds.Count, readOnCreateContacts.Count);

            foreach (var contact in readOnCreateContacts)
            {
                Assert.NotNull(contact);
                Assert.NotNull(contact.Id);
                Assert.NotEmpty(contact.Id);
            }

            // -------------------End Bulk Read Contact-------------------


            // -------------------Bulk Update Contact-------------------
            Dictionary<string, string> contactNameDic = new Dictionary<string, string>();

            foreach (var contact in readOnCreateContacts)
            {
                contactNameDic[contact.Id] = contact.PrimaryAddressPostalcode;
            }

            response = ContactsModule.BulkUpdateContact(client, readOnCreateContacts);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<string> updateIds = (response.Data == null) ? null : ((IList) response.Data).Cast<string>().ToList();

            Assert.NotNull(updateIds);
            foreach (string id in updateIds)
            {
                Assert.NotNull(id);
                Assert.NotEmpty(id);
            }
            // -------------------End Bulk Update Contact-------------------


            // -------------------Bulk Read Contact-------------------
            List<Contact> readOnUpdateContacts = ContactsModule.BulkReadContact2(client, updateIds);

            Assert.NotNull(readOnUpdateContacts);
            Assert.Equal(updateIds.Count, readOnUpdateContacts.Count);

            foreach (var item in contactNameDic)
            {
                Contact contact = readOnUpdateContacts.FirstOrDefault(x => x.Id == item.Key);
                Assert.NotNull(contact);
                Assert.NotEqual(item.Value, contact.PrimaryAddressPostalcode);
            }
            // -------------------End Bulk Read Contact-------------------


            // -------------------Bulk Delete Contact-------------------
            List<string> deleteIds = ContactsModule.BulkDeleteContact(client, updateIds);

            Assert.NotNull(deleteIds);
            Assert.Equal(updateIds.Count, deleteIds.Count);

            List<string> comparedIds = deleteIds.Except(updateIds, StringComparer.OrdinalIgnoreCase).ToList();

            if (comparedIds != null)
            {
                Assert.Equal(comparedIds.Count, 0);
            }
            // -------------------End Bulk Delete Contact-------------------
        }

        [Fact]
        public void ReadByTypeTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Contact insertContact = ContactsModule.GetTestContact();

            // -------------------Create Contact-------------------
            SugarRestResponse response = ContactsModule.CreateContactByType(client, insertContact);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Contact-------------------


            // -------------------Read Contact-------------------
            response = ContactsModule.ReadContactByType(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Contact readOnCreateContact = (Contact) response.Data;

            Assert.NotNull(readOnCreateContact);
            Assert.Equal(insertContact.FirstName, readOnCreateContact.FirstName);
            Assert.Equal(insertContact.LastName, readOnCreateContact.LastName);
            Assert.Equal(insertContact.Title, readOnCreateContact.Title);
            Assert.Equal(insertContact.PrimaryAddressPostalcode, readOnCreateContact.PrimaryAddressPostalcode);
            // -------------------End Read Contact-------------------


            // -------------------Delete Contact-------------------
            response = ContactsModule.DeleteContactByType(client, readOnCreateContact.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = (response.Data == null) ? string.Empty : response.Data.ToString();
 
            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Contact-------------------
        }

        [Fact]
        public async void ReadAsyncTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            Contact insertContact = ContactsModule.GetTestContact();

            // -------------------Create Contact-------------------
            SugarRestResponse response = await ContactsModule.CreateContactAsync(client, insertContact);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string insertId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(insertId);
            Assert.NotEmpty(insertId);
            // -------------------End Create Contact-------------------


            // -------------------Read Contact-------------------
            response = await ContactsModule.ReadContactAsync(client, insertId);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            Contact readOnCreateContact = (Contact) response.Data;

            Assert.NotNull(readOnCreateContact);
            Assert.Equal(insertContact.FirstName, readOnCreateContact.FirstName);
            Assert.Equal(insertContact.LastName, readOnCreateContact.LastName);
            Assert.Equal(insertContact.Title, readOnCreateContact.Title);
            Assert.Equal(insertContact.PrimaryAddressPostalcode, readOnCreateContact.PrimaryAddressPostalcode);
            // -------------------End Read Contact-------------------


            // -------------------Delete Contact-------------------
            response = await ContactsModule.DeleteContactAsync(client, readOnCreateContact.Id);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            string deleteId = (response.Data == null) ? string.Empty : response.Data.ToString();

            Assert.NotNull(deleteId);
            Assert.NotEmpty(deleteId);
            Assert.Equal(insertId, deleteId);
            // -------------------End Delete Contact-------------------
        }

        [Fact]
        public void ReadBulkTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Contact-------------------
            int count = 10;
            SugarRestResponse response = ContactsModule.BulkReadContact(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Contact> readContacts = (List<Contact>) (response.Data);
            Assert.NotNull(readContacts);
            Assert.True(readContacts.Count <= count);
            // -------------------End Bulk Read Contact-------------------
        }

        [Fact]
        public async void ReadBulkAsyncTest()
        {
            var client = new SugarRestClient(TestAccount.Url, TestAccount.Username, TestAccount.Password);

            // -------------------Bulk Read Contact-------------------
            int count = 25;
            SugarRestResponse response = await ContactsModule.BulkReadContactAsync(client, count);

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            List<Contact> readContacts = (List<Contact>) response.Data;
            Assert.NotNull(readContacts);
            Assert.True(readContacts.Count <= count);
            // -------------------End Bulk Read Contact-------------------
        }
    }
}
