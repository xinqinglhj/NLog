// 
// Copyright (c) 2004-2016 Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 

#if !NETSTANDARD || WCF_SUPPORTED

namespace NLog.LogReceiverService
{
    using System;
#if WCF_SUPPORTED
    using System.ServiceModel;
#endif
    /// <summary>
    /// Service contract for Log Receiver client.
    /// </summary>
    /// <remarks>This class marked as obsolete before NLog 4.3.11 and it may be removed in a future release.</remarks>
#if WCF_SUPPORTED
    [ServiceContract(Namespace = LogReceiverServiceConfig.WebServiceNamespace, ConfigurationName = "NLog.LogReceiverService.ILogReceiverClient")]
#endif
    [Obsolete("Use ILogReceiverOneWayClient or ILogReceiverTwoWayClient instead. Marked obsolete before v4.3.11 and it may be removed in a future release.")]
    public interface ILogReceiverClient
    {
        /// <summary>
        /// Begins processing of log messages.
        /// </summary>
        /// <param name="events">The events.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="asyncState">Asynchronous state.</param>
        /// <returns>
        /// IAsyncResult value which can be passed to <see cref="EndProcessLogMessages"/>.
        /// </returns>
#if WCF_SUPPORTED
        [OperationContractAttribute(AsyncPattern = true, Action = "http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessages", ReplyAction = "http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessagesResponse")]
#endif
        IAsyncResult BeginProcessLogMessages(NLogEvents events, AsyncCallback callback, object asyncState);

        /// <summary>
        /// Ends asynchronous processing of log messages.
        /// </summary>
        /// <param name="result">The result.</param>
        void EndProcessLogMessages(IAsyncResult result);
    }
}

#endif