using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WolframAlpha.Api.v2.Attributes;
using System.Reflection;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2
{
    /// <summary>
    /// Easily generate a query to the Wolfram Alpha API.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{QueryUri.AbsoluteUri}")]
    public sealed class QueryBuilder
    {

        #region Parameters

        /// <summary>
        /// Specifies the input string, such as "5 largest countries". 
        /// 
        /// Required.
        /// </summary>
        [QueryParameter("input", true)]
        public string Input { get; set; }
        /// <summary>
        /// An ID provided by Wolfram Research that identifies the application or organization making the request.
        /// 
        /// Required.
        /// </summary>
        [QueryParameter("appid", true)]
        public string AppId { get; set; }
        /// <summary>
        /// The desired result format(s). Possible values are image, plaintext, minput, moutput, cell, mathml, imagemap, sound, wav. To request more than one format type, separate values with a comma: "plaintext,minput,image".
        /// 
        /// Optional; defaults to "plaintext,image".
        /// </summary>
        [QueryParameter("format")]
        public string Format { get; set; }
        /// <summary>
        /// Specifies a pod ID to include. You can specify more than one of these elements in the query. Only pods with the given IDs will be returned.
        /// 
        /// Optional; default is all pods.
        /// </summary>
        [QueryParameter("includepodid")]
        public string IncludePodId { get; set; }
        /// <summary>
        /// Specifies a pod ID to exclude. You can specify more than one of these elements in the query. Pods with the given IDs will be excluded from the result.
        /// 
        /// Optional; default is to exclude no pods.
        /// </summary>
        [QueryParameter("excludepodid")]
        public string ExcludePodId { get; set; }
        /// <summary>
        /// Specifies a pod title. You can specify more than one of these elements in the query. Only pods with the given titles will be returned. You can use * as a wildcard to match zero or more characters in pod titles.
        /// 
        /// Optional; default is all pods.
        /// </summary>
        [QueryParameter("podtitle")]
        public string PodTitle { get; set; }
        /// <summary>
        /// Specifies the index of the pod(s) to return. This is an alternative to specifying pods by title or ID. You can give a single number or a sequence like "2,3,5".
        /// 
        /// Optional; default is all pods.
        /// </summary>
        [QueryParameter("podindex")]
        public string PodIndex { get; set; }
        /// <summary>
        /// Specifies that only pods produced by the given scanner should be returned. You can specify more than one of these elements in the query.
        /// 
        /// Optional; default is all pods.
        /// </summary>
        [QueryParameter("scanner")]
        public string Scanner { get; set; }
        /// <summary>
        /// Wolfram|Alpha can use an asynchronous mode that allows partial results to come back before all the pods are computed. See the section "Timeouts and Asynchronous Behavior" for more details.
        /// 
        /// Optional; defaults to false.
        /// </summary>
        [QueryParameter("async")]
        public string Async { get; set; }

        /// <summary>
        /// The ip parameter lets you set the IP address of the caller, so if you are forwarding calls from your own web visitors to the Wolfram|Alpha API, you can propagate their IP addresses.
        /// </summary>
        [QueryParameter("ip")]
        public string IP { get; set; }
        /// <summary>
        /// The location parameter lets you specify a string like "Los Angeles, CA", or "Madrid"
        /// </summary>
        [QueryParameter("location")]
        public string Location { get; set; }
        /// <summary>
        /// The latlong parameter lets you specify a latitude/longitude pair like "40.42,-3.71". Negative latitude values are South, and negative longitude values are West.
        /// </summary>
        [QueryParameter("latlong")]
        public string LatLong { get; set; }

        /// <summary>
        /// Specifies an assumption, such as the meaning of a word or the value of a formula variable. See the "Assumptions" section for more details.
        /// 
        /// Optional.
        /// </summary>
        [QueryParameter("assumption")]
        public string Assumption { get; set; }
        /// <summary>
        /// Specifies a pod state change, which replaces a pod with a modified version, such as a switch from Imperial to metric units. See the "Pod States" section for more details.
        /// 
        /// Optional.
        /// </summary>
        [QueryParameter("podstate")]
        public string PodState { get; set; }
        /// <summary>
        /// Specifies a pod state change, which replaces a pod with a modified version, such as a switch from Imperial to metric units. See the "Pod States" section for more details.
        /// 
        /// Optional.
        /// </summary>
        [QueryParameter("units")]
        public string Units { get; set; }

        /// <summary>
        /// Wolfram|Alpha formats pod images to a default maximum width of 500 pixels. If you want to change this width, such as for a small mobile device screen, the API provides three parameters you can use.
        /// width and maxwidth, apply to images of text and tables, which are the majority of Wolfram|Alpha output. 
        /// </summary>
        [QueryParameter("width")]
        public string Width { get; set; }
        /// <summary>
        /// Wolfram|Alpha formats pod images to a default maximum width of 500 pixels. If you want to change this width, such as for a small mobile device screen, the API provides three parameters you can use.
        /// width and maxwidth, apply to images of text and tables, which are the majority of Wolfram|Alpha output. 
        /// </summary>
        [QueryParameter("maxwidth")]
        public string MaxWidth { get; set; }
        /// <summary>
        /// Wolfram|Alpha formats pod images to a default maximum width of 500 pixels. If you want to change this width, such as for a small mobile device screen, the API provides three parameters you can use.
        /// The plotwidth parameter controls the width at which plots and graphics are rendered. The default value is 200 pixels. There are many graphics in Wolfram|Alpha that are deliberately rendered at larger sizes to accommodate their content. Specifying plotwidth is currently an experimental feature that does not yet affect many type of graphics.
        /// </summary>
        [QueryParameter("plotwidth")]
        public string PlotWidth { get; set; }
        /// <summary>
        /// The mag parameter controls the magnification of pod images. The default value is 1.0, meaning no magnification. 
        /// Magnification does not affect the pixel width of images, so if you specify a width parameter, or accept the default of 500 pixels, 
        /// images will still come back at that size if you specify a magnification value. 
        /// What happens is that if you specify, say, mag=2, then the pod image is formatted to a width of half the requested width 
        /// (say, 250 pixels) and then blown up by a factor of 2 during rendering, to 500 pixels.        
        /// </summary>
        [QueryParameter("mag")]
        public string Mag { get; set; }

        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to compute results in the "scan" stage of processing. See the section "Timeouts and Asynchronous Behavior" for more details.
        /// 
        /// Optional; defaults to 3.0.
        /// </summary>
        [QueryParameter("scantimeout")]
        public string ScanTimeout { get; set; }
        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to spend in the "format" stage for any one pod. See the section "Timeouts and Asynchronous Behavior" for more details.
        /// 
        /// Optional; defaults to 4.0.
        /// </summary>
        [QueryParameter("podtimeout")]
        public string PodTimeout { get; set; }
        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to spend in the "format" stage for the entire collection of pods. See the section "Timeouts and Asynchronous Behavior" for more details.
        /// 
        /// Optional; defaults to 8.0.
        /// </summary>
        [QueryParameter("formattimeout")]
        public string FormatTimeout { get; set; }
        /// <summary>
        /// The number of seconds to allow Wolfram|Alpha to spend in the "parsing" stage of processing. See the section "Timeouts and Asynchronous Behavior" for more details.
        /// 
        /// Optional; defaults to 5.0.
        /// </summary>
        [QueryParameter("parsetimeout")]
        public string ParseTimeout { get; set; }

        /// <summary>
        /// Whether to allow Wolfram|Alpha to reinterpret queries that would otherwise not be understood. See the section "Some Miscellaneous URL Parameters" for more details.
        /// 
        /// Optional; defaults to false.
        /// </summary>
        [QueryParameter("reinterpret")]
        public string Reinterpret { get; set; }
        /// <summary>
        /// Whether to allow Wolfram|Alpha to try to translate simple queries into English. See the section "Some Miscellaneous URL Parameters" for more details.
        /// 
        /// Optional; defaults to true.
        /// </summary>
        [QueryParameter("translation")]
        public string Translation { get; set; }
        /// <summary>
        /// Whether to force Wolfram|Alpha to ignore case in queries. See the section "Some Miscellaneous URL Parameters" for more details.
        /// 
        /// Optional; defaults to false.
        /// </summary>
        [QueryParameter("ignorecase")]
        public string IgnoreCase { get; set; }
        /// <summary>
        /// A special signature that can be applied to guard against misuse of your AppID.
        /// 
        /// Optional.
        /// </summary>
        [QueryParameter("sig")]
        public string Sig { get; set; }

        #endregion

        #region Uris

        /// <summary>
        /// Returns a query uri with the supplied parameter values.
        /// </summary>
        public Uri QueryUri
        {
            get
            {
                return BuildQueryUri(ApiConstants.QueryBaseUrl);
            }
        }
        /// <summary>
        /// Returns a validatequery uri with the supplied parameter values.
        /// </summary>
        public Uri ValidateQueryString
        {
            get
            {
                return BuildQueryUri(ApiConstants.ValidateQueryBaseUrl);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance of the QueryBuilder class.
        /// </summary>
        public QueryBuilder()
        {

        }
        /// <summary>
        /// Initialize a new instance of the QueryBuilder class, providing a previously created query uri.
        /// </summary>
        /// <param name="queryUri"></param>
        public QueryBuilder(Uri queryUri)
        {
            if (queryUri == null)
                throw new ArgumentNullException("queryUri");
            Contract.EndContractBlock();

            InitializeFromQuery(queryUri.Query);
        }

        #endregion

        #region Query Strings

        private void InitializeFromQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return;

            if (query.StartsWith("?"))
                query = query.Substring(1);

            //Parse the query string into key/value pairs.
            var valueCollection = new HttpValueCollectionLite(query);

            //Match the metadata attribute name with the query string key.
            var join = valueCollection
                .Join(_queryParametersMetadata.Value, o => o.Key, p => p.Item2.Name, (o, p) => new { Metadata = p, Value = o }, StringComparer.OrdinalIgnoreCase)
                .Where(q => q.Metadata.Item1.CanWrite);
            
            //Set each property to the query string value.
            foreach (var item in join)
            {
                item.Metadata.Item1.SetValue(this, item.Value.Value, null);
            }
        }

        private Uri BuildQueryUri(string baseUrl)
        {
            var uri = new UriBuilder(baseUrl);
            var uriQuery = uri.Query;

            var queryString = GetQueryString();
            if (string.IsNullOrEmpty(queryString))
                return uri.Uri;
            if (queryString.EndsWith("&"))
                queryString = queryString.Substring(0, queryString.Length - 1);

            if (!string.IsNullOrEmpty(uriQuery) && uriQuery.Length > 1)
            {
                uri.Query = uriQuery.Substring(1) + "&" + queryString;
            }
            else
            {
                uri.Query = queryString;
            }
            return uri.Uri;
        }
        private string GetQueryString()
        {
            var s = new System.Text.StringBuilder();
            foreach (var pair in GetQueryValues())
            {
                s.Append(Uri.EscapeDataString(pair.Key) + "=" + Uri.EscapeDataString(pair.Value) + "&");
            }
            return s.ToString();
        }
        private IDictionary<string, string> GetQueryValues()
        {
            return _queryParametersMetadata.Value
                .Select(o => new { Tuple = o, Value = Convert.ToString(o.Item1.GetValue(this, null)) })
                .Where(p => p.Tuple.Item2.Required || !string.IsNullOrWhiteSpace(p.Value))
                .ToDictionary(p => p.Tuple.Item2.Name, p => p.Value);
        }
        private static Lazy<Tuple<PropertyInfo, QueryParameterAttribute>[]> _queryParametersMetadata = new Lazy<Tuple<PropertyInfo, QueryParameterAttribute>[]>(GetQueryParametersMetadata);
        private static Tuple<PropertyInfo, QueryParameterAttribute>[] GetQueryParametersMetadata()
        {
            return typeof(QueryBuilder).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(o => o.CanRead && Attribute.IsDefined(o, typeof(QueryParameterAttribute)))
                .Select(o => new Tuple<PropertyInfo, QueryParameterAttribute>(o, Attribute.GetCustomAttribute(o, typeof(QueryParameterAttribute)) as QueryParameterAttribute))
                .ToArray();
        }

        #endregion

    }
}