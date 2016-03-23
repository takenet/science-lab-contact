using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Wolfram|Alpha can automatically try to reinterpret a query that it does not understand but that seems close to one that it can. 
    /// This behavior drastically reduces the number of failed queries, at the cost of potentially giving the user a result that is far from the original intent.
    /// </summary>
    [XmlRoot("reinterpret")]
    [System.Diagnostics.DebuggerDisplay("{Text,nq}")]
    public class ReinterpretWarning
    {

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }
        
        /// <summary>
        /// New.
        /// </summary>
        [XmlAttribute("new")]
        public string New { get; set; }

        /// <summary>
        /// In some cases, additional suggested interpretations are provided as alternative subelements to the reinterpret element.
        /// </summary>
        [XmlElement("alternative")]
        public string[] Alternatives { get; set; }

    }
}