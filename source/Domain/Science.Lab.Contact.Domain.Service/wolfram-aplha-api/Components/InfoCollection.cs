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
    /// Some pods on the Wolfram|Alpha website have text buttons in their lower-right corners that provide extra information about the contents of that pod.
    /// The data for these "information" links is available in the API via the infos element, which appears inside any pod elements for which information links are available.
    /// </summary>
    [XmlRoot("infos")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class InfoCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Infos.
        /// </summary>
        [XmlElement("info")]
        public Info[] Infos { get; set; }

        /// <summary>
        /// Get Info by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Info</returns>
        [XmlIgnore()]
        public Info this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Infos.Length);
                
                return Infos[i];
            }
        }

    }
}