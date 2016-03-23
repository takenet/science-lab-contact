using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// If you enter "chicag" as a query, Wolfram|Alpha assumes you meant "chicago."
    /// </summary>
    [XmlRoot("spellcheck")]
    [System.Diagnostics.DebuggerDisplay("{Word,nq}")]
    public class SpellCheckWarning
    {

        /// <summary>
        /// Word.
        /// </summary>
        [XmlAttribute("word")]
        public string Word { get; set; }

        /// <summary>
        /// Suggestion.
        /// </summary>
        [XmlAttribute("suggestion")]
        public string Suggestion { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

    }
}