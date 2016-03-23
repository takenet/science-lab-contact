using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace WolframAlpha.Api.v2.Http
{
    /// <summary>
    /// Interface for an HttpClientFactory
    /// </summary>
    [CLSCompliant(false)]
    public interface IHttpClientFactory
    {

        /// <summary>
        /// Create a new instance of an HttpClient.
        /// </summary>
        /// <returns></returns>
        HttpClient CreateClient();

        /// <summary>
        /// Create a new instance of an HttpRequestMessage.
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        HttpRequestMessage CreateRequestMessage(HttpMethod httpMethod, Uri requestUri);

    }
}