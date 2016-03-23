using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace WolframAlpha.Api.v2.Http
{
    /// <summary>
    /// Default implementation of the IHttpClientFactory interface.
    /// </summary>
    internal class DefaultHttpClientFactory : IHttpClientFactory
    {

        /// <summary>
        /// Create a new instance of an HttpClient.
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateClient()
        {
            return new HttpClient();
        }

        /// <summary>
        /// Create a new instance of an HttpRequestMessage.
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public HttpRequestMessage CreateRequestMessage(HttpMethod httpMethod, Uri requestUri)
        {
            return new HttpRequestMessage(httpMethod, requestUri);
        }

    }
}