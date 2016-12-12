// -----------------------------------------------------------------------
// <copyright file="SugarRestRequest.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Text;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    /// <summary>
    /// Represents SugarRestRequest class
    /// </summary>
    public class SugarRestRequest
    {
        /// <summary>
        /// The validation message
        /// </summary>
        private string _validationMessage;

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class
        /// </summary>
        public SugarRestRequest()
        {
            this.Options = new Options();
            this._validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class
        /// </summary>
        public SugarRestRequest(string moduleName)
        {
            this.ModuleName = moduleName;
            this.Options = new Options();
            this._validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class
        /// </summary>
        public SugarRestRequest(RequestType requestType)
        {
            this.RequestType = requestType;
            this.Options = new Options();
            this._validationMessage = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestRequest class
        /// </summary>
        public SugarRestRequest(string moduleName, RequestType requestType)
        {
            this.ModuleName = moduleName;
            this.RequestType = requestType;
            this.Options = new Options();
            this._validationMessage = string.Empty;
        }
        /// <summary>
        /// Gets or sets REST API Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets REST API Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets REST API Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Sugar Crm module name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets Sugar Crm module name
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Gets or sets entity identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets entity or entities data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets options object
        /// </summary>
        public Options Options { get; set; }

        /// <summary>
        /// Gets the validation message
        /// </summary>
        public string ValidationMessage 
        {
            get { return this._validationMessage; }
        }

        /// <summary>
        /// Checks whether the request is valid
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

                    if (string.IsNullOrEmpty(ModuleName))
                    {
                        builder.AppendLine(ErrorCodes.ModulenameInvalid);
                    }

                    switch (RequestType)
                    {
                        case RequestType.ReadById:
                        case RequestType.Delete:
                            if (string.IsNullOrEmpty(this.Id))
                            {
                                builder.AppendLine(ErrorCodes.IdInvalid);
                            }

                            break;

                        case RequestType.Create:
                        case RequestType.BulkCreate:
                        case RequestType.BulkUpdate:
                            if (this.Data == null)
                            {
                                builder.AppendLine(ErrorCodes.DataInvalid);
                            }

                            break;

                        case RequestType.LinkedReadById:
                            if (string.IsNullOrEmpty(this.Id))
                            {
                                builder.AppendLine(ErrorCodes.IdInvalid);
                            }

                            if ((Options.LinkedFields == null) || (Options.LinkedFields.Count ==0))
                            {
                                builder.AppendLine(ErrorCodes.LinkedFieldsInfoMissing);
                            }
                            break;

                        case RequestType.LinkedBulkRead:
                            if ((Options.LinkedFields == null) || (Options.LinkedFields.Count == 0))
                            {
                                builder.AppendLine(ErrorCodes.LinkedFieldsInfoMissing);
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                }

                this._validationMessage = builder.ToString();
                return string.IsNullOrEmpty(this._validationMessage);
            }
        }
    }
}
