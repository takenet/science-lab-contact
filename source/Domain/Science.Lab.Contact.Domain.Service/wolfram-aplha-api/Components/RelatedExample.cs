using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// RelatedExample.
    /// </summary>
    [XmlRoot("relatedexample")]
    [System.Diagnostics.DebuggerDisplay("{Input,nq}")]
    public class RelatedExample
    {

        /// <summary>
        /// Input.
        /// </summary>
        [XmlAttribute("input")]
        public string Input { get; set; }

        /// <summary>
        /// Desc.
        /// </summary>
        [XmlAttribute("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        [XmlAttribute("category")]
        public string Category { get; set; }

        /// <summary>
        /// CategoryThumb.
        /// </summary>
        [XmlAttribute("categorythumb")]
        public string CategoryThumb { get; set; }

        /// <summary>
        /// CategoryPage.
        /// </summary>
        [XmlAttribute("categorypage")]
        public string CategoryPage { get; set; }

    }
}