using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// If Wolfram|Alpha cannot understand your query, but recognizes it as a foreign language, it will generate a languagemsg element.    
    /// </summary>
    [XmlRoot("languagemsg")]
    [System.Diagnostics.DebuggerDisplay("{English,nq}")]
    public class LanguageMsg
    {

        /// <summary>
        /// Textual message in English.
        /// </summary>
        [XmlAttribute("english")]
        public string English { get; set; }

        /// <summary>
        /// Textual message in whatever language the query appears to be.
        /// </summary>
        [XmlAttribute("other")]
        public string Other { get; set; }

    }
}