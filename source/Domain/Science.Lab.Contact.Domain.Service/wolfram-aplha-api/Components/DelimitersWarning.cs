using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// If you enter a query with mismatched delimiters like "sin(x", Wolfram|Alpha attempts to fix the problem and reports this as a warning.
    /// </summary>
    [XmlRoot("delimiters")]
    [System.Diagnostics.DebuggerDisplay("{Text,nq}")]
    public class DelimitersWarning
    {

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

    }
}