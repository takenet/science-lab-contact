using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WolframAlpha.Api.v2
{
    /// <summary>
    /// Constants.
    /// </summary>
    public static class ApiConstants
    {

        /// <summary>
        /// Base URL for a query.
        /// </summary>
        public const string QueryBaseUrl = @"http://api.wolframalpha.com/v2/query";

        /// <summary>
        /// Base URL for a validate query.
        /// </summary>
        public const string ValidateQueryBaseUrl = @"http://api.wolframalpha.com/v2/validatequery";

    }
}