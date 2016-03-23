using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Tip.
    /// </summary>
    [XmlRoot("tip")]
    [System.Diagnostics.DebuggerDisplay("{Text,nq}")]
    public class Tip
    {

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

    }
}