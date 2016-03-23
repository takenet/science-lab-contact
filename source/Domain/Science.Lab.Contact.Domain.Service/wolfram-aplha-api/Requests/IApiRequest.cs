using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using WolframAlpha.Api.v2.Components;

namespace WolframAlpha.Api.v2.Requests
{
    /// <summary>
    /// Interface for an api request.
    /// </summary>
    [ContractClass(typeof(ApiRequestContract<>))]
    public interface IApiRequest<T>
        where T : ApiResult
    {
        
        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        Task<T> ExecuteAsync(Uri requestUri);
        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> ExecuteAsync(Uri requestUri, CancellationToken cancellationToken);

    }
}