using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Components;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2.Requests
{
    [ContractClassFor(typeof(IApiRequest<>))]
    internal abstract class ApiRequestContract<T> : IApiRequest<T>
        where T : ApiResult
    {


        public Task<T> ExecuteAsync(Uri requestUri)
        {
            Contract.Requires(requestUri != null);

            return default(Task<T>);
        }

        public Task<T> ExecuteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            Contract.Requires(requestUri != null);
            
            return default(Task<T>);
        }

    }
}