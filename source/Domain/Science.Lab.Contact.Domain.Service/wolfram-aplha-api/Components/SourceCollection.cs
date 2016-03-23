using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The sources element is a subelement of queryresult.
    /// The sources element contains a series of source subelements, each one defining a link to a web page of source information.
    /// </summary>
    [XmlRoot("sources")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class SourceCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Sources.
        /// </summary>
        [XmlElement("source")]
        public Source[] Sources { get; set; }

        /// <summary>
        /// Get Source by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Source</returns>
        [XmlIgnore()]
        public Source this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Sources.Length);
                
                return Sources[i];
            }
        }

    }
}