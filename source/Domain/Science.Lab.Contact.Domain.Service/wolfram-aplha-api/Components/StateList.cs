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
    /// Some states are logically grouped into sets.
    /// </summary>
    [XmlRoot("statelist")]
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class StateList
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// The value attribute of the statelist element names the state that is currently in effect.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        /// States.
        /// </summary>
        [XmlElement("state")]
        public State[] States { get; set; }

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

        private string DebuggerDisplay { get { return string.Format("Count: {0} Value: {1}", Count, Value); } }

    }
}