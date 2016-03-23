using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// When a query cannot be meaningfully computed, but is recognized by Wolfram|Alpha as a category for which a set of example queries has already been prepared, 
    /// it generates an examplepage element. 
    /// Conceptually, this is a bit like the relatedexamples element, but here the query is more of a "direct hit" on a specific topic.
    /// </summary>
    [XmlRoot("examplepage")]
    [System.Diagnostics.DebuggerDisplay("{Url,nq}")]
    public class ExamplePage
    {

        /// <summary>
        /// Category.
        /// </summary>
        [XmlAttribute("category")]
        public string Category { get; set; }

        /// <summary>
        /// The url attribute gives a link to an HTML page of sample queries in the topic.
        /// </summary>
        [XmlAttribute("url")]
        public string Url { get; set; }

    }
}