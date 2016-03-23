using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// For some types of queries, Wolfram|Alpha decides that although it can provide some results for the precise query that was given, 
    /// there is a "generalization" of the query for which more information can be provided.
    /// </summary>
    [XmlRoot("generalization")]
    [System.Diagnostics.DebuggerDisplay("{Url,nq}")]
    public class Generalization
    {

        /// <summary>
        /// Topic.
        /// </summary>
        [XmlAttribute("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// Desc.
        /// </summary>
        [XmlAttribute("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        [XmlAttribute("url")]
        public string Url { get; set; }

    }
}