using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Components;

namespace WolframAlpha.Api.v2.Serializers
{
    /// <summary>
    /// Default implementation of the IApiSerializerFactory interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultApiSerializerFactory<T> : IApiSerializerFactory<T>
        where T : ApiResult
    {

        /// <summary>
        /// Create a new instance of an ApiSerializer.
        /// </summary>
        /// <returns></returns>
        public IApiSerializer<T> CreateApiSerializer()
        {
            return new ApiSerializer<T>();
        }

    }
}