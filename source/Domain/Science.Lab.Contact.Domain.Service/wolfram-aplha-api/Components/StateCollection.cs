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
    /// The states element is a subelement of pod or subpod.
    /// </summary>
    [XmlRoot("states")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class StateCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// States.
        /// </summary>
        [XmlElement("state")]
        public State[] States { get; set; }

        /// <summary>
        /// StateLists.
        /// </summary>
        [XmlElement("statelist")]
        public StateList[] StateLists { get; set; }

        /// <summary>
        /// Get State by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>State.</returns>
        [XmlIgnore()]
        public State this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < States.Length);
                
                return States[i];
            }
        }

    }
}