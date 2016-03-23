using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Each info element represents one piece of information about the contents of the pod.
    /// </summary>
    [XmlRoot("info")]
    [System.Diagnostics.DebuggerDisplay("{Text,nq}")]
    public class Info
    {

        /// <summary>
        /// Some info lines contain descriptive text along with one or more links. The text is provided in the text attribute of the info element.
        /// </summary>
        [XmlAttribute("text")]
        public string Text { get; set; }

        /// <summary>
        /// The img element contains a link to an image of the text.
        /// </summary>
        [XmlElement("img")]
        public Image[] Imgs { get; set; }

        /// <summary>
        /// Used when the item is just a standard link of some text pointing to a URL.
        /// </summary>
        [XmlElement("link")]
        public Link[] Links { get; set; }

        /// <summary>
        /// Used when the link is a popup window showing a table of unit abbreviations used in the pod alongside their long names.
        /// </summary>
        [XmlElement("units")]
        public UnitsCollection Units { get; set; }

    }
}