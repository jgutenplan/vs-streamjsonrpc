﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace StreamJsonRpc
{
    using System;
    using Microsoft;

    /// <summary>
    /// Options that may customize how a target object is added to a <see cref="JsonRpc"/> instance.
    /// </summary>
    public class JsonRpcTargetOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcTargetOptions"/> class.
        /// </summary>
        public JsonRpcTargetOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonRpcTargetOptions"/> class.
        /// </summary>
        /// <param name="copyFrom">An instance to copy all property values from.</param>
        public JsonRpcTargetOptions(JsonRpcTargetOptions copyFrom)
        {
            Requires.NotNull(copyFrom, nameof(copyFrom));

            this.MethodNameTransform = copyFrom.MethodNameTransform;
            this.EventNameTransform = copyFrom.EventNameTransform;
            this.NotifyClientOfEvents = copyFrom.NotifyClientOfEvents;
            this.AllowNonPublicInvocation = copyFrom.AllowNonPublicInvocation;
            this.UseSingleObjectParameterDeserialization = copyFrom.UseSingleObjectParameterDeserialization;
            this.DisposeOnDisconnect = copyFrom.DisposeOnDisconnect;
        }

        /// <summary>
        /// Gets or sets a function that takes the CLR method name and returns the RPC method name.
        /// This method is useful for adding prefixes to all methods, or making them camelCased.
        /// </summary>
        public Func<string, string>? MethodNameTransform { get; set; }

        /// <summary>
        /// Gets or sets a function that takes the CLR event name and returns the RPC event name used in notification messages.
        /// This method is useful for adding prefixes to all events, or making them camelCased.
        /// </summary>
        public Func<string, string>? EventNameTransform { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether events raised on the target object
        /// should be relayed to the client via a JSON-RPC notify message.
        /// </summary>
        /// <value>The default is <c>true</c>.</value>
        public bool NotifyClientOfEvents { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether non-public methods/events on target objects can be invoked
        /// by remote clients.
        /// </summary>
        /// <value>The default value is <c>false</c>.</value>
        /// <remarks>
        /// The default for this property was <c>true</c> in the 1.x versions.
        /// </remarks>
        public bool AllowNonPublicInvocation { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether JSON-RPC named arguments should all be deserialized into the RPC method's first parameter.
        /// </summary>
        public bool UseSingleObjectParameterDeserialization { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to dispose of the target object
        /// when the connection with the remote party is lost.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The target object may implement <see cref="System.IAsyncDisposable"/>,
        /// <see cref="Microsoft.VisualStudio.Threading.IAsyncDisposable"/> or <see cref="IDisposable"/>.
        /// The first implemented interface from this list is the one whose dispose method will be invoked.
        /// </para>
        /// <para>
        /// Exceptions thrown from the dispose method will be aggregated into <see cref="JsonRpc.Completion"/>.
        /// </para>
        /// </remarks>
        public bool DisposeOnDisconnect { get; set; }

        /// <summary>
        /// Gets an instance with default properties.
        /// </summary>
        /// <remarks>
        /// Callers should *not* mutate properties on this instance since it is shared.
        /// </remarks>
        internal static JsonRpcTargetOptions Default { get; } = new JsonRpcTargetOptions();
    }
}
