using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// subpod elements are subelements of pod. Each contains the results for a single subpod.
    /// </summary>
    [XmlRoot("subpod")]
    [System.Diagnostics.DebuggerDisplay("{PlainText,nq}")]
    public class SubPod
    {

        /// <summary>
        /// Title, usually an empty string.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// plaintext elements are the textual representation of a single subpod. They only appear if the requested result formats include plaintext.
        /// </summary>
        [XmlElement("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// Image.
        /// </summary>
        [XmlElement("img")]
        public Image Img { get; set; }

        /// <summary>
        /// ImageMap.
        /// </summary>
        [XmlElement("imagemap")]
        public ImageMap ImageMap { get; set; }

        /// <summary>
        /// mathml elements enclose the Presentation MathML representation of a single subpod. They only appear if the requested result formats include mathml.
        /// </summary>
        [XmlElement("mathml")]
        public string MathML { get; set; }

        /// <summary>
        /// States.
        /// </summary>
        [XmlElement("states")]
        public StateCollection States { get; set; }

    }
}