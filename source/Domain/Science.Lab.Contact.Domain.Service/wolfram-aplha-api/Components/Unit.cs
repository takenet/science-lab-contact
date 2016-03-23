using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Unit.
    /// </summary>
    [XmlRoot("unit")]
    [System.Diagnostics.DebuggerDisplay("{Short,nq}")]
    public class Unit
    {

        /// <summary>
        /// Short name.
        /// </summary>
        [XmlAttribute("short")]
        public string Short { get; set; }

        /// <summary>
        /// Long name.
        /// </summary>
        [XmlAttribute("long")]
        public string Long { get; set; }

    }
}