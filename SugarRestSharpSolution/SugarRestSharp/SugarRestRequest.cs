// -----------------------------------------------------------------------
// <copyright file="SugarRestRequest.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents SugarRestRequest class
    /// </summary>
    public class SugarRestRequest
    {
        /// <summary>
        /// The validation message
        /// </summary>
        private string validationMessage;

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class.
        /// </summary>
        public SugarRestRequest()
        {
            this.Options = new Options();
            this.validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class.
        /// </summary>
        /// <param name="moduleName">The SugarCrm module name.</param>
        public SugarRestRequest(string moduleName)
        {
            this.ModuleName = moduleName;
            this.Options = new Options();
            this.validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class.
        /// </summary>
        /// <param name="requestType">The request type.</param>
        public SugarRestRequest(RequestType requestType)
        {
            this.RequestType = requestType;
            this.Options = new Options();
            this.validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class.
        /// </summary>
        /// <param name="moduleName">The SugarCrm module name.</param>
        /// <param name="requestType">The request type.</param>
        public SugarRestRequest(string moduleName, RequestType requestType)
        {
            this.ModuleName = moduleName;
            this.RequestType = requestType;
            this.Options = new Options();
            this.validationMessage = string.Empty;
        }

        /// <summary>
        /// Gets or sets SugarCrm REST API Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets REST API Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets REST API Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets SugarCrm module name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets SugarCrm module name.
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Gets or sets request parameter - can be identifier, entity or entities data.
        /// Parameter type set for the following request type:
        /// ReadById - Identifier (Id)
        /// BulkRead - null (Set options if needed.)
        /// PagedRead - null (Set options if needed.)
        /// Create - Entity
        /// BulkCreate - Entity collection
        /// Update - Entity
        /// BulkUpdate - Entity collection
        /// Delete - Identifier (Id)
        /// LinkedReadById - Identifier (Id) (Linked option value must be set.) 
        /// LinkedBulkRead - null (Linked option value must be set.)
        /// </summary>
        public object Parameter { get; set; }

        /// <summary>
        /// Gets or sets options object.
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Gets the validation message.
        /// </summary>
        public string ValidationMessage 
        {
            get { return this.validationMessage; }
        }

        /// <summary>
        /// Gets a value indicating whether the request is valid.
        /// </summary>
        /// <param name="type">Request type</param>
        /// <returns>True or false</returns>
        public bool IsValid
        {
            get
            {
                var builder = new StringBuilder();

                try
                {
                    if (string.IsNullOrEmpty(this.Url))
                    {
                        builder.AppendLine(ErrorCodes.UrlInvalid);
                    }

                    if (string.IsNullOrEmpty(this.Username))
                    {
                        builder.AppendLine(ErrorCodes.UsernameInvalid);
                    }

                    if (string.IsNullOrEmpty(this.Password))
                    {
                        builder.AppendLine(ErrorCodes.PasswordInvalid);
                    }

                    if (string.IsNullOrEmpty(this.ModuleName))
                    {
                        builder.AppendLine(ErrorCodes.ModulenameInvalid);
                    }

                    switch (RequestType)
                    {
                        case RequestType.ReadById:
                        case RequestType.Delete:
                        if (this.Parameter == null)
                        {
                            builder.AppendLine(ErrorCodes.IdInvalid);
                        }

                        break;

                        case RequestType.Create:
                        case RequestType.BulkCreate:
                        case RequestType.BulkUpdate:
                        if (this.Parameter == null)
                        {
                            builder.AppendLine(ErrorCodes.DataInvalid);
                        }

                        break;

                        case RequestType.LinkedReadById:
                        if (this.Parameter == null)
                        {
                            builder.AppendLine(ErrorCodes.IdInvalid);
                        }

                        if ((Options.LinkedModules == null) || (Options.LinkedModules.Count == 0))
                        {
                            builder.AppendLine(ErrorCodes.LinkedFieldsInfoMissing);
                        }

                        break;

                        case RequestType.LinkedBulkRead:
                        if ((Options.LinkedModules == null) || (Options.LinkedModules.Count == 0))
                        {
                            builder.AppendLine(ErrorCodes.LinkedFieldsInfoMissing);
                        }

                        break;
                    }
                }
                catch (Exception)
                {
                }

                this.validationMessage = builder.ToString();
                return string.IsNullOrEmpty(this.validationMessage);
            }
        }
    }
}
