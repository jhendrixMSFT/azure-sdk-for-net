// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Management.Sql
{
    /// <summary>
    /// Contains operations for getting dropped Azure SQL Databases that can be
    /// restored.
    /// </summary>
    internal partial class RestorableDroppedDatabaseOperations : IServiceOperations<SqlManagementClient>, Microsoft.WindowsAzure.Management.Sql.IRestorableDroppedDatabaseOperations
    {
        /// <summary>
        /// Initializes a new instance of the
        /// RestorableDroppedDatabaseOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RestorableDroppedDatabaseOperations(SqlManagementClient client)
        {
            this._client = client;
        }
        
        private SqlManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Sql.SqlManagementClient.
        /// </summary>
        public SqlManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Returns information about a dropped Azure SQL Database that can be
        /// restored.
        /// </summary>
        /// <param name='serverName'>
        /// Required. The name of the Azure SQL Database Server on which the
        /// database was hosted.
        /// </param>
        /// <param name='entityId'>
        /// Required. The entity ID of the restorable dropped Azure SQL
        /// Database to be obtained.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Contains the response to the Get Restorable Dropped Database
        /// request.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.Sql.Models.RestorableDroppedDatabaseGetResponse> GetAsync(string serverName, string entityId, CancellationToken cancellationToken)
        {
            // Validate
            if (serverName == null)
            {
                throw new ArgumentNullException("serverName");
            }
            if (entityId == null)
            {
                throw new ArgumentNullException("entityId");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serverName", serverName);
                tracingParameters.Add("entityId", entityId);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId.Trim() + "/services/sqlservers/servers/" + serverName.Trim() + "/restorabledroppeddatabases/" + entityId.Trim();
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2012-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RestorableDroppedDatabaseGetResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new RestorableDroppedDatabaseGetResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement serviceResourceElement = responseDoc.Element(XName.Get("ServiceResource", "http://schemas.microsoft.com/windowsazure"));
                    if (serviceResourceElement != null && serviceResourceElement.IsEmpty == false)
                    {
                        RestorableDroppedDatabase serviceResourceInstance = new RestorableDroppedDatabase();
                        result.Database = serviceResourceInstance;
                        
                        XElement entityIdElement = serviceResourceElement.Element(XName.Get("EntityId", "http://schemas.microsoft.com/windowsazure"));
                        if (entityIdElement != null && entityIdElement.IsEmpty == false)
                        {
                            string entityIdInstance = entityIdElement.Value;
                            serviceResourceInstance.EntityId = entityIdInstance;
                        }
                        
                        XElement nameElement = serviceResourceElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                        if (nameElement != null && nameElement.IsEmpty == false)
                        {
                            string nameInstance = nameElement.Value;
                            serviceResourceInstance.Name = nameInstance;
                        }
                        
                        XElement serverNameElement = serviceResourceElement.Element(XName.Get("ServerName", "http://schemas.microsoft.com/windowsazure"));
                        if (serverNameElement != null && serverNameElement.IsEmpty == false)
                        {
                            string serverNameInstance = serverNameElement.Value;
                            serviceResourceInstance.ServerName = serverNameInstance;
                        }
                        
                        XElement editionElement = serviceResourceElement.Element(XName.Get("Edition", "http://schemas.microsoft.com/windowsazure"));
                        if (editionElement != null && editionElement.IsEmpty == false)
                        {
                            string editionInstance = editionElement.Value;
                            serviceResourceInstance.Edition = editionInstance;
                        }
                        
                        XElement maxSizeBytesElement = serviceResourceElement.Element(XName.Get("MaxSizeBytes", "http://schemas.microsoft.com/windowsazure"));
                        if (maxSizeBytesElement != null && maxSizeBytesElement.IsEmpty == false)
                        {
                            long maxSizeBytesInstance = long.Parse(maxSizeBytesElement.Value, CultureInfo.InvariantCulture);
                            serviceResourceInstance.MaximumDatabaseSizeInBytes = maxSizeBytesInstance;
                        }
                        
                        XElement creationDateElement = serviceResourceElement.Element(XName.Get("CreationDate", "http://schemas.microsoft.com/windowsazure"));
                        if (creationDateElement != null && creationDateElement.IsEmpty == false)
                        {
                            DateTime creationDateInstance = DateTime.Parse(creationDateElement.Value, CultureInfo.InvariantCulture);
                            serviceResourceInstance.CreationDate = creationDateInstance;
                        }
                        
                        XElement deletionDateElement = serviceResourceElement.Element(XName.Get("DeletionDate", "http://schemas.microsoft.com/windowsazure"));
                        if (deletionDateElement != null && deletionDateElement.IsEmpty == false)
                        {
                            DateTime deletionDateInstance = DateTime.Parse(deletionDateElement.Value, CultureInfo.InvariantCulture);
                            serviceResourceInstance.DeletionDate = deletionDateInstance;
                        }
                        
                        XElement recoveryPeriodStartDateElement = serviceResourceElement.Element(XName.Get("RecoveryPeriodStartDate", "http://schemas.microsoft.com/windowsazure"));
                        if (recoveryPeriodStartDateElement != null && recoveryPeriodStartDateElement.IsEmpty == false && string.IsNullOrEmpty(recoveryPeriodStartDateElement.Value) == false)
                        {
                            DateTime recoveryPeriodStartDateInstance = DateTime.Parse(recoveryPeriodStartDateElement.Value, CultureInfo.InvariantCulture);
                            serviceResourceInstance.RecoveryPeriodStartDate = recoveryPeriodStartDateInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Returns a collection of databases that has been dropped but can
        /// still be restored from a specified server.
        /// </summary>
        /// <param name='serverName'>
        /// Required. The name of the Azure SQL Database Server to query for
        /// dropped databases that can still be restored.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Contains the response to the List Restorable Dropped Databases
        /// request.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.Sql.Models.RestorableDroppedDatabaseListResponse> ListAsync(string serverName, CancellationToken cancellationToken)
        {
            // Validate
            if (serverName == null)
            {
                throw new ArgumentNullException("serverName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serverName", serverName);
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId.Trim() + "/services/sqlservers/servers/" + serverName.Trim() + "/restorabledroppeddatabases?contentview=generic";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2012-03-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    RestorableDroppedDatabaseListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new RestorableDroppedDatabaseListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement serviceResourcesSequenceElement = responseDoc.Element(XName.Get("ServiceResources", "http://schemas.microsoft.com/windowsazure"));
                    if (serviceResourcesSequenceElement != null && serviceResourcesSequenceElement.IsEmpty == false)
                    {
                        foreach (XElement serviceResourcesElement in serviceResourcesSequenceElement.Elements(XName.Get("ServiceResource", "http://schemas.microsoft.com/windowsazure")))
                        {
                            RestorableDroppedDatabase serviceResourceInstance = new RestorableDroppedDatabase();
                            result.Databases.Add(serviceResourceInstance);
                            
                            XElement entityIdElement = serviceResourcesElement.Element(XName.Get("EntityId", "http://schemas.microsoft.com/windowsazure"));
                            if (entityIdElement != null && entityIdElement.IsEmpty == false)
                            {
                                string entityIdInstance = entityIdElement.Value;
                                serviceResourceInstance.EntityId = entityIdInstance;
                            }
                            
                            XElement nameElement = serviceResourcesElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                            if (nameElement != null && nameElement.IsEmpty == false)
                            {
                                string nameInstance = nameElement.Value;
                                serviceResourceInstance.Name = nameInstance;
                            }
                            
                            XElement serverNameElement = serviceResourcesElement.Element(XName.Get("ServerName", "http://schemas.microsoft.com/windowsazure"));
                            if (serverNameElement != null && serverNameElement.IsEmpty == false)
                            {
                                string serverNameInstance = serverNameElement.Value;
                                serviceResourceInstance.ServerName = serverNameInstance;
                            }
                            
                            XElement editionElement = serviceResourcesElement.Element(XName.Get("Edition", "http://schemas.microsoft.com/windowsazure"));
                            if (editionElement != null && editionElement.IsEmpty == false)
                            {
                                string editionInstance = editionElement.Value;
                                serviceResourceInstance.Edition = editionInstance;
                            }
                            
                            XElement maxSizeBytesElement = serviceResourcesElement.Element(XName.Get("MaxSizeBytes", "http://schemas.microsoft.com/windowsazure"));
                            if (maxSizeBytesElement != null && maxSizeBytesElement.IsEmpty == false)
                            {
                                long maxSizeBytesInstance = long.Parse(maxSizeBytesElement.Value, CultureInfo.InvariantCulture);
                                serviceResourceInstance.MaximumDatabaseSizeInBytes = maxSizeBytesInstance;
                            }
                            
                            XElement creationDateElement = serviceResourcesElement.Element(XName.Get("CreationDate", "http://schemas.microsoft.com/windowsazure"));
                            if (creationDateElement != null && creationDateElement.IsEmpty == false)
                            {
                                DateTime creationDateInstance = DateTime.Parse(creationDateElement.Value, CultureInfo.InvariantCulture);
                                serviceResourceInstance.CreationDate = creationDateInstance;
                            }
                            
                            XElement deletionDateElement = serviceResourcesElement.Element(XName.Get("DeletionDate", "http://schemas.microsoft.com/windowsazure"));
                            if (deletionDateElement != null && deletionDateElement.IsEmpty == false)
                            {
                                DateTime deletionDateInstance = DateTime.Parse(deletionDateElement.Value, CultureInfo.InvariantCulture);
                                serviceResourceInstance.DeletionDate = deletionDateInstance;
                            }
                            
                            XElement recoveryPeriodStartDateElement = serviceResourcesElement.Element(XName.Get("RecoveryPeriodStartDate", "http://schemas.microsoft.com/windowsazure"));
                            if (recoveryPeriodStartDateElement != null && recoveryPeriodStartDateElement.IsEmpty == false && string.IsNullOrEmpty(recoveryPeriodStartDateElement.Value) == false)
                            {
                                DateTime recoveryPeriodStartDateInstance = DateTime.Parse(recoveryPeriodStartDateElement.Value, CultureInfo.InvariantCulture);
                                serviceResourceInstance.RecoveryPeriodStartDate = recoveryPeriodStartDateInstance;
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
