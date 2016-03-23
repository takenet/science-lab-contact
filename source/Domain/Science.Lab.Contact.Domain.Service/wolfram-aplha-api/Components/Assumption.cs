using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The assumption element is a subelement of assumptions. 
    /// It defines a single assumption, typically about the meaning of a word or phrase, and a series of possible other values.
    /// </summary>
    [XmlRoot("assumption")]
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Assumption
    {

        /// <summary>
        /// Type.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// Word.
        /// </summary>
        [XmlAttribute("word")]
        public string Word { get; set; }

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Values.
        /// </summary>
        [XmlElement("value")]
        public AssumptionValue[] Values { get; set; }

        private string DebuggerDisplay { get { return string.Format("{0} {1}", this.Type, this.Word); } }

    }
}