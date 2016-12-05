// -----------------------------------------------------------------------
// <copyright file="SugarRestRequest.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarCrm.RestfulCRUD
{
    using Newtonsoft.Json.Linq;
    using SugarCrm.RestApiCalls;
    using System.Collections.Generic;
    using System.Text;

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
            this._validationMessage = string.Empty;
            Options = new Options();
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
        /// Gets or sets entity identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets entity or entities data
        /// </summary>
        public List<object> Data { get; set; }

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
        public bool IsValid(RequestType type)
        {
            var builder = new StringBuilder();
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

            switch (type)
            {
                case RequestType.GetById:
                case RequestType.Delete:
                    if (string.IsNullOrEmpty(this.Id))
                    {
                        builder.AppendLine(ErrorCodes.IdInvalid);
                    }

                    break;

                case RequestType.Insert:
                    if (this.Data == null)
                    {
                        builder.AppendLine(ErrorCodes.DataInvalid);
                    }

                    break;

                case RequestType.Update:
                    if (string.IsNullOrEmpty(this.Id))
                    {
                        builder.AppendLine(ErrorCodes.IdInvalid);
                    }

                    if (this.Data == null)
                    {
                        builder.AppendLine(ErrorCodes.DataInvalid);
                    }

                    break;
            }

            this._validationMessage = builder.ToString();
            return string.IsNullOrEmpty(this._validationMessage);
        }
    }
}
