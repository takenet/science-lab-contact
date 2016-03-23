using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Queries that refer to topics that are under development generate a futuretopic element.
    /// </summary>
    [XmlRoot("futuretopic")]
    [System.Diagnostics.DebuggerDisplay("{Topic,nq}")]
    public class FutureTopic
    {

        /// <summary>
        /// Topic.
        /// </summary>
        [XmlAttribute("topic")]
        public string Topic { get; set; }

        /// <summary>
        /// Msg.
        /// </summary>
        [XmlAttribute("msg")]
        public string Msg { get; set; }

    }
}