using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using WolframAlpha.Api.v2.Components;
using System.Xml;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2.Serializers
{
    /// <summary>
    /// XmlSerializer for the WolframAlpha api.
    /// </summary>
    /// <typeparam name="TResult">Subclass of ApiResult</typeparam>
    public class ApiSerializer<TResult> : IApiSerializer<TResult>
        where TResult : ApiResult
    {

        private readonly XmlSerializer _serializer;

        /// <summary>
        /// Create a new ApiSerializer instance.
        /// </summary>
        public ApiSerializer()
        {
            _serializer = new XmlSerializer(typeof(TResult));            
        }

        /// <summary>
        /// Deserialize directly into an ApiResult.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public TResult Deserialize(string s)
        {
            if (string.IsNullOrEmpty(s))
                return default(TResult);

            using (var r = new System.IO.StringReader(s))
            {
                return (TResult)_serializer.Deserialize(r);
            }
        }
        /// <summary>
        /// Deserialize directly into an ApiResult.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public TResult Deserialize(System.IO.Stream stream)
        {
            return (TResult)_serializer.Deserialize(stream);
        }

    }
}