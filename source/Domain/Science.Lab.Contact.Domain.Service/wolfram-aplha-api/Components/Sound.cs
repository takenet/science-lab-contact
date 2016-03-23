using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Sound.
    /// </summary>
    [XmlRoot("sound")]
    [System.Diagnostics.DebuggerDisplay("{Url,nq}")]
    public class Sound
    {

        /// <summary>
        /// Url.
        /// </summary>
        [XmlAttribute("url")]
        public string Url { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }


    }
}