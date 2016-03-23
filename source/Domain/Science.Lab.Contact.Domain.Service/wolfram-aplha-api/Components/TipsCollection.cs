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
    /// Each tip gives a line of text that you might choose to display to users.
    /// </summary>
    [XmlRoot("tips")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class TipsCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Tips.
        /// </summary>
        [XmlElement("tip")]
        public Tip[] Tips { get; set; }

        /// <summary>
        /// Get Tip by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Tip</returns>
        [XmlIgnore()]
        public Tip this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Tips.Length);
                
                return Tips[i];
            }
        }

    }
}