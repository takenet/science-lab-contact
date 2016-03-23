using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Components;

namespace WolframAlpha.Api.v2.Serializers
{
    /// <summary>
    /// Interface for a serializer.
    /// </summary>
    public interface IApiSerializer<TResult>
        where TResult : ApiResult
    {

        /// <summary>
        /// Deserialize directly into an ApiResult.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        TResult Deserialize(string s);

        /// <summary>
        /// Deserialize directly into an ApiResult.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        TResult Deserialize(System.IO.Stream stream);

    }
}