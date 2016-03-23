using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Components;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WolframAlpha.Api.v2.Http;
using WolframAlpha.Api.v2.Serializers;

namespace WolframAlpha.Api.v2.Requests
{
    /// <summary>
    /// Base class for a request to the WolframAlpha API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ApiRequest<T> : IApiRequest<T>
        where T : ApiResult
    {

        /// <summary>
        /// HttpClientFactory implementation for creating HttpClient instances.
        /// If not provided, a <see cref="WolframAlpha.Api.v2.Http.DefaultHttpClientFactory"/> will be used.
        /// </summary>
        [CLSCompliant(false)]
        public IHttpClientFactory HttpClientFactory { get; set; }

        /// <summary>
        /// IApiSerializerFactory implementation for creating ApiSerializer instances.
        /// If not provided, a <see cref="WolframAlpha.Api.v2.Serializers.DefaultApiSerializerFactory{T}"/> will be used.
        /// </summary>
        public IApiSerializerFactory<T> ApiSerializerFactory { get; set; }

        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync(Uri requestUri)
        {
            return await ExecuteAsync(requestUri, CancellationToken.None).ConfigureAwait(false);
        }
        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            using (var responseMessage = await SendRequestAsync(requestUri, cancellationToken).ConfigureAwait(false))
            {
                cancellationToken.ThrowIfCancellationRequested();

                var apiSerializerFactory = this.ApiSerializerFactory ?? new DefaultApiSerializerFactory<T>();
                return await DeserializeResponseMessage(apiSerializerFactory, responseMessage).ConfigureAwait(false);
            }
        }
        private async Task<HttpResponseMessage> SendRequestAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            Contract.Assume(requestUri != null);
            Contract.Assume(cancellationToken != null);

            var httpClientFactory = this.HttpClientFactory ?? new DefaultHttpClientFactory();

            using (var requestMessage = CreateRequestMessage(httpClientFactory, requestUri))
            {
                using (var httpClient = CreateHttpClient(httpClientFactory))
                {
                    return await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
                }
            }
        }
        private async Task<T> DeserializeResponseMessage(IApiSerializerFactory<T> apiSerializerFactory, HttpResponseMessage responseMessage)
        {
            Contract.Assume(apiSerializerFactory != null);
            Contract.Assume(responseMessage != null);

            //Throw HttpRequestException if not successful.
            responseMessage.EnsureSuccessStatusCode();

            //An XML response is expected.            
            var stream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var serializer = apiSerializerFactory.CreateApiSerializer();
            return serializer.Deserialize(stream);
        }

        /// <summary>
        /// Create the HttpRequestMessage.
        /// </summary>
        /// <returns></returns>
        private HttpRequestMessage CreateRequestMessage(IHttpClientFactory httpClientFactory, Uri requestUri)
        {
            Contract.Assume(httpClientFactory != null);
            Contract.Assume(requestUri != null);

            return httpClientFactory.CreateRequestMessage(HttpMethod.Get, requestUri);
        }
        /// <summary>
        /// Create the HttpClient.
        /// </summary>
        /// <returns></returns>
        private HttpClient CreateHttpClient(IHttpClientFactory httpClientFactory)
        {
            Contract.Assume(httpClientFactory != null);

            return httpClientFactory.CreateClient();
        }

    }
}