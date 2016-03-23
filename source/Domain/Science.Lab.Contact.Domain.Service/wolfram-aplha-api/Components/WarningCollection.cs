using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The warnings element occurs as a subelement of queryresult. 
    /// It contains warning subelements, each of which describes a particular warning generated during the query.
    /// </summary>
    [XmlRoot("warnings")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class WarningCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// SpellChecks.
        /// </summary>
        [XmlElement("spellcheck")]
        public SpellCheckWarning[] SpellChecks { get; set; }

        /// <summary>
        /// Delimiters.
        /// </summary>
        [XmlElement("delimiters")]
        public DelimitersWarning[] Delimiters { get; set; }

        /// <summary>
        /// Translations.
        /// </summary>
        [XmlElement("translation")]
        public TranslationWarning[] Translations { get; set; }

        /// <summary>
        /// Reinterprets.
        /// </summary>
        [XmlElement("reinterpret")]
        public ReinterpretWarning[] Reinterprets { get; set; }
        

    }
}