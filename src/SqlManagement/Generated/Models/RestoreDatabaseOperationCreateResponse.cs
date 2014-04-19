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
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Management.Sql.Models
{
    /// <summary>
    /// Contains the response to the Create Restore Database Operation request.
    /// </summary>
    public partial class RestoreDatabaseOperationCreateResponse : OperationResponse
    {
        private RestoreDatabaseOperation _operation;
        
        /// <summary>
        /// Optional. Gets the operation that has been returned from a Create
        /// Restore Database Operation request.
        /// </summary>
        public RestoreDatabaseOperation Operation
        {
            get { return this._operation; }
            set { this._operation = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the
        /// RestoreDatabaseOperationCreateResponse class.
        /// </summary>
        public RestoreDatabaseOperationCreateResponse()
        {
        }
    }
}
