using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// img elements are HTML img elements suitable for direct inclusion in a web page. 
    /// They point to stored image files giving a formatted visual representation of a single subpod. 
    /// They only appear in pods if the requested result formats include img. 
    /// In most cases, the image will be in GIF format, although in a few cases it will be in JPEG format. 
    /// The filename in the img URL will tell you whether it is GIF or JPEG.
    /// </summary>
    [XmlRoot("img")]
    [System.Diagnostics.DebuggerDisplay("{Src,nq}")]
    public class Image
    {

        /// <summary>
        /// Src.
        /// </summary>
        [XmlAttribute("src")]
        public string Src { get; set; }

        /// <summary>
        /// Alt.
        /// </summary>
        [XmlAttribute("alt")]
        public string Alt { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// Width.
        /// </summary>
        [XmlAttribute("width")]
        public string Width { get; set; }

        /// <summary>
        /// Height.
        /// </summary>
        [XmlAttribute("height")]
        public string Height { get; set; }

    }
}