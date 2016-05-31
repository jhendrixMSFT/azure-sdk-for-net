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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    /// <summary>
    /// The Resource Manager API includes operations for triggering and
    /// managing actions of the file / folder recovery of items protected by
    /// your Recovery Services Vault.
    /// </summary>
    public partial interface IFileFolderRestoreOperations
    {
        /// <summary>
        /// Provisions an iSCSI connection which can be used to download a
        /// script which when run opens the file explorer displaying all
        /// recoverable files and folders. This is an asynchronous operation.
        /// To determine whether the backend service has finished processing
        /// the request, call Get Protected Item Operation Result API.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='fabricName'>
        /// Fabric name of the protected item.
        /// </param>
        /// <param name='containerName'>
        /// Name of the container where the protected item belongs to.
        /// </param>
        /// <param name='protectedItemName'>
        /// Name of the protected item whose files / folders are to be restored.
        /// </param>
        /// <param name='recoveryPointId'>
        /// ID of the recovery point whose files / folders are to be restored.
        /// </param>
        /// <param name='request'>
        /// File / folder restore request for the backup item.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Base recovery job response for all the asynchronous operations.
        /// </returns>
        Task<BaseRecoveryServicesJobResponse> ProvisionAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string fabricName, string containerName, string protectedItemName, string recoveryPointId, ProvisionILRRequest request, CancellationToken cancellationToken);
        
        /// <summary>
        /// Revokes an iSCSI connection which can be used to download a script
        /// which when run opens the file explorer displaying all recoverable
        /// files and folders. This is an asynchronous operation. To determine
        /// whether the backend service has finished processing the request,
        /// call --- API.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='fabricName'>
        /// Fabric name of the protected item.
        /// </param>
        /// <param name='containerName'>
        /// Name of the container where the protected item belongs to.
        /// </param>
        /// <param name='protectedItemName'>
        /// Name of the protected item whose files / folders are to be restored.
        /// </param>
        /// <param name='recoveryPointId'>
        /// ID of the recovery point whose files / folders are to be restored.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        Task<AzureOperationResponse> RevokeAsync(string resourceGroupName, string resourceName, CustomRequestHeaders customRequestHeaders, string fabricName, string containerName, string protectedItemName, string recoveryPointId, CancellationToken cancellationToken);
    }
}
