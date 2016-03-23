using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Components;

namespace WolframAlpha.Api.v2.Serializers
{
    /// <summary>
    /// Interface for an ApiSerializerFactory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiSerializerFactory<T>
        where T : ApiResult
    {

        /// <summary>
        /// Create a new instance of an ApiSerializer.
        /// </summary>
        /// <returns></returns>
        IApiSerializer<T> CreateApiSerializer();

    }
}