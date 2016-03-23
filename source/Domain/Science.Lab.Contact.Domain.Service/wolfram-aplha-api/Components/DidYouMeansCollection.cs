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
    /// The Wolfram|Alpha website sometimes has a "Did you mean" prompt that suggests a different query close in spelling to the one you entered. 
    /// This alternative suggestion is available in the API via the didyoumeans element.
    /// </summary>
    [XmlRoot("didyoumeans")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class DidYouMeansCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// DidYouMeans.
        /// </summary>
        [XmlElement("didyoumean")]
        public string[] DidYouMeans { get; set; }

        /// <summary>
        /// Get DidYouMeans by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>DidYouMeans</returns>
        [XmlIgnore()]
        public string this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < DidYouMeans.Length); 

                return DidYouMeans[i];
            }
        }

    }
}