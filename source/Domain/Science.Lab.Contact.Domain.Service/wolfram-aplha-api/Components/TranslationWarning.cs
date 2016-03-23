using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Wolfram|Alpha will translate some queries from non-English languages into English.
    /// At present, the only way to see the translation warning is to turn on automatic translation with the translation=true URL parameter.
    /// </summary>
    [XmlRoot("translation")]
    [System.Diagnostics.DebuggerDisplay("{Phrase,nq}")]
    public class TranslationWarning
    {

        /// <summary>
        /// Phrase.
        /// </summary>
        [XmlAttribute("phrase")]
        public string Phrase { get; set; }

        /// <summary>
        /// Trans.
        /// </summary>
        [XmlAttribute("trans")]
        public string Trans { get; set; }

        /// <summary>
        /// Lang.
        /// </summary>
        [XmlAttribute("lang")]
        public string Lang { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

    }
}