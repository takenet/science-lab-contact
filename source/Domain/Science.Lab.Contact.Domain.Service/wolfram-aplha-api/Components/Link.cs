using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Url link.
    /// </summary>
    [XmlRoot("link")]
    [System.Diagnostics.DebuggerDisplay("{Url,nq}")]
    public class Link
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

        /// <summary>
        /// Title.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

    }
}