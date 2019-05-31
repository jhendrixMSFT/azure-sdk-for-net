// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Batch.Protocol.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The network configuration for a pool.
    /// </summary>
    public partial class NetworkConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the NetworkConfiguration class.
        /// </summary>
        public NetworkConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NetworkConfiguration class.
        /// </summary>
        /// <param name="subnetId">The ARM resource identifier of the virtual
        /// network subnet which the compute nodes of the pool will
        /// join.</param>
        /// <param name="dynamicVNetAssignmentScope">The scope of dynamic vnet
        /// assignment.</param>
        /// <param name="endpointConfiguration">The configuration for endpoints
        /// on compute nodes in the Batch pool.</param>
        public NetworkConfiguration(string subnetId = default(string), DynamicVNetAssignmentScope? dynamicVNetAssignmentScope = default(DynamicVNetAssignmentScope?), PoolEndpointConfiguration endpointConfiguration = default(PoolEndpointConfiguration))
        {
            SubnetId = subnetId;
            DynamicVNetAssignmentScope = dynamicVNetAssignmentScope;
            EndpointConfiguration = endpointConfiguration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ARM resource identifier of the virtual network
        /// subnet which the compute nodes of the pool will join.
        /// </summary>
        /// <remarks>
        /// This is of the form
        /// /subscriptions/{subscription}/resourceGroups/{group}/providers/{provider}/virtualNetworks/{network}/subnets/{subnet}.
        /// The virtual network must be in the same region and subscription as
        /// the Azure Batch account. The specified subnet should have enough
        /// free IP addresses to accommodate the number of nodes in the pool.
        /// If the subnet doesn't have enough free IP addresses, the pool will
        /// partially allocate compute nodes, and a resize error will occur.
        /// For pools created with virtualMachineConfiguration only ARM virtual
        /// networks ('Microsoft.Network/virtualNetworks') are supported, but
        /// for pools created with cloudServiceConfiguration both ARM and
        /// classic virtual networks are supported. For more details, see:
        /// https://docs.microsoft.com/en-us/azure/batch/batch-api-basics#virtual-network-vnet-and-firewall-configuration
        /// </remarks>
        [JsonProperty(PropertyName = "subnetId")]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the scope of dynamic vnet assignment.
        /// </summary>
        /// <remarks>
        /// Possible values include: 'none', 'job'
        /// </remarks>
        [JsonProperty(PropertyName = "dynamicVNetAssignmentScope")]
        public DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get; set; }

        /// <summary>
        /// Gets or sets the configuration for endpoints on compute nodes in
        /// the Batch pool.
        /// </summary>
        /// <remarks>
        /// Pool endpoint configuration is only supported on pools with the
        /// virtualMachineConfiguration property.
        /// </remarks>
        [JsonProperty(PropertyName = "endpointConfiguration")]
        public PoolEndpointConfiguration EndpointConfiguration { get; set; }

    }
}