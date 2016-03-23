using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Source.
    /// </summary>
    [XmlRoot("source")]
    [System.Diagnostics.DebuggerDisplay("{Url,nq}")]
    public class Source
    {

        /// <summary>
        /// Url.
        /// </summary>
        [XmlAttribute("url")]
        public string Url { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

    }
}